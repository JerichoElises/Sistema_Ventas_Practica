
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SVServices.Interfaces;
using MimeKit.Text;

namespace SVServices.Implementation
{
    public class CorreoService : ICorreoService
    {
        private readonly IConfiguration _configuracion;
        private SmtpClient _smtp;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;

        public CorreoService(IConfiguration configuration)
        {
            _configuracion = configuration;

            _smtp = new SmtpClient();
            _host = _configuracion["Smtp:host"]!;
            _port = Convert.ToInt32(_configuracion["Smtp:port"]!);
            _user = _configuracion["Smtp:user"]!;
            _pass = _configuracion["Smtp:pass"]!;
        }
        public async Task Enviar(string para, string asunto, string mensajeHtml)
        {
            _smtp = new SmtpClient();
            _smtp.Connect(_host, _port,SecureSocketOptions.StartTls);
            _smtp.Authenticate(_user, _pass);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_user));
            email.To.Add(MailboxAddress.Parse(para));
            email.Subject = asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = mensajeHtml
            };

            await _smtp.SendAsync(email);
            await _smtp.DisconnectAsync(true);
        }
    }
}
