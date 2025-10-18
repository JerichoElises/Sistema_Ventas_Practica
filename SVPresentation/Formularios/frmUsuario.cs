using SVPresentation.Utilidades.Objetos;
using SVPresentation.Utilidades;
using SVPresentation.ViewModels;
using SVServices.Implementation;
using SVServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SV_Repository.Entities;

namespace SVPresentation.Formularios
{
    public partial class frmUsuario : Form
    {
        private readonly IRolService _rolService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICorreoService _correoService;
        public frmUsuario(IRolService rolService, IUsuarioService usuarioService, ICorreoService correoService)
        {
            InitializeComponent();
            _rolService = rolService;
            _usuarioService = usuarioService;
            _correoService = correoService;
        }

        public void MostrarTab(string tabName)
        {
            var TabsMenu = new TabPage[] { tabLista, tabNuevo, tabEditar };

            foreach (var tab in TabsMenu)
            {
                if (tab.Name != tabName)
                {
                    tab.Parent = null;
                }
                else
                {
                    tab.Parent = tabControlMain;
                }
            }
        }

        private async Task MostrarUsuarios(string buscar = "")
        {
            var listaUsuario = await _usuarioService.Lista(buscar);
            var listaVM = listaUsuario.Select(item => new UsuarioVM
            {
                IdUsuario = item.IdUsuario,
                IdRol = item.RefRol.IdRol,
                Rol = item.RefRol.Nombre,
                NombreCompleto = item.NombreCompleto,
                Correo = item.Correo,
                NombreUsuario = item.NombreUsuario,
                Activo = item.Activo,
                Habilitado = item.Activo == 1 ? "SI" : "NO"
            }).ToList();

            dgvUsuarios.DataSource = listaVM;

            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible = false;
            dgvUsuarios.Columns["Activo"].Visible = false;
        }

        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
            dgvUsuarios.ImplementarConfiguracion("Editar");
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            await MostrarUsuarios();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[] {
                new OpcionCombo { Texto ="Si", Valor = 1},
                new OpcionCombo { Texto ="No", Valor = 0},
            };

            var listaRol = await _rolService.Lista();
            var items = listaRol.Select(item => new OpcionCombo { Texto = item.Nombre, Valor = item.IdRol }).ToArray();

            cbbRolNuevo.InsertarItems(items);
            cbbRolEditar.InsertarItems(items);

            cbbHabilitado.InsertarItems(itemsHabilitado);

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarUsuarios(txbBuscar.Text);
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            cbbRolNuevo.SelectedIndex = 0;
            txbNombreCompletoNuevo.Text = "";
            txbCorreoNuevo.Text = "";
            txbNombreUsuarioNuevo.Text = "";
            MostrarTab(tabNuevo.Name);
            cbbRolNuevo.Select();
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (txbNombreCompletoNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el nombre completo");
                return;
            }
            if (txbCorreoNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el correo");
                return;
            }
            if (txbNombreUsuarioNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el nombre de usuario");
                return;
            }

            var claveGenerada = Util.GenerateCode();
            var claveSha256 = Util.ConvertToSha256(claveGenerada);

            var objeto = new Usuario
            {
                RefRol = new Rol { IdRol = ((OpcionCombo)cbbRolNuevo.SelectedItem!).Valor },
                NombreCompleto = txbNombreCompletoNuevo.Text.Trim(),
                Correo = txbCorreoNuevo.Text.Trim(),
                NombreUsuario = txbNombreUsuarioNuevo.Text.Trim(),
                Clave = claveGenerada
            };

            var respuesta = await _usuarioService.Crear(objeto);

            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                var mensaje = $"Bienvenido<br>Su contraseña temporal es:{claveGenerada}</br>";
                await _correoService.Enviar(objeto.Correo, "Cuenta Creada", mensaje);

                await MostrarUsuarios();
                MostrarTab(tabLista.Name);
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var usuarioSeleccionada = (UsuarioVM)dgvUsuarios.CurrentRow.DataBoundItem;

                cbbRolEditar.EstablecerValor(usuarioSeleccionada.IdRol);
                txbNombreCompletoEditar.Text = usuarioSeleccionada.NombreCompleto;
                txbCorreoEditar.Text = usuarioSeleccionada.Correo;
                txbNombreUsuarioEditar.Text = usuarioSeleccionada.NombreUsuario;
                cbbHabilitado.EstablecerValor(usuarioSeleccionada.Activo);

                MostrarTab(tabEditar.Name);
                cbbRolEditar.Select();
            }
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(tabLista.Name);
        }

        private async void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (txbNombreCompletoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el nombre completo");
                return;
            }
            if (txbCorreoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el correo");
                return;
            }
            if (txbNombreUsuarioEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el nombre de usuario");
                return;
            }

            var usuarioSeleccionada = (UsuarioVM)dgvUsuarios.CurrentRow.DataBoundItem;

            var objeto = new Usuario
            {
                IdUsuario = usuarioSeleccionada.IdUsuario,
                RefRol = new Rol { IdRol = ((OpcionCombo)cbbRolEditar.SelectedItem!).Valor },
                NombreCompleto = txbNombreCompletoEditar.Text.Trim(),
                Correo = txbCorreoEditar.Text.Trim(),
                NombreUsuario = txbNombreUsuarioEditar.Text.Trim(),
                Activo = ((OpcionCombo) cbbHabilitado.SelectedItem!).Valor
            };

            var respuesta = await _usuarioService.Editar(objeto);

            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                await MostrarUsuarios();
                MostrarTab(tabLista.Name);
            }

        }
    }
}
