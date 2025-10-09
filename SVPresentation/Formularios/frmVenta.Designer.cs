namespace SVPresentation.Formularios
{
    partial class frmVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRegistar = new Button();
            btnBuscar = new Button();
            txbPagoCon = new TextBox();
            label7 = new Label();
            txbCambio = new TextBox();
            txbNombreCliente = new TextBox();
            label5 = new Label();
            txbCodigoProducto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label8 = new Label();
            label6 = new Label();
            label9 = new Label();
            lblTotal = new Label();
            dgvDetalleVenta = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // btnRegistar
            // 
            btnRegistar.BackColor = Color.White;
            btnRegistar.Cursor = Cursors.Hand;
            btnRegistar.FlatStyle = FlatStyle.Flat;
            btnRegistar.ForeColor = Color.FromArgb(30, 90, 195);
            btnRegistar.Location = new Point(665, 365);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(75, 23);
            btnRegistar.TabIndex = 38;
            btnRegistar.Text = "Registrar";
            btnRegistar.UseVisualStyleBackColor = false;
            btnRegistar.Click += btnRegistar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(500, 80);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 36;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txbPagoCon
            // 
            txbPagoCon.Location = new Point(348, 366);
            txbPagoCon.Name = "txbPagoCon";
            txbPagoCon.Size = new Size(88, 23);
            txbPagoCon.TabIndex = 31;
            txbPagoCon.KeyDown += txbPagoCon_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Location = new Point(282, 369);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 30;
            label7.Text = "Pago con:";
            // 
            // txbCambio
            // 
            txbCambio.Location = new Point(558, 366);
            txbCambio.Name = "txbCambio";
            txbCambio.ReadOnly = true;
            txbCambio.Size = new Size(88, 23);
            txbCambio.TabIndex = 29;
            // 
            // txbNombreCliente
            // 
            txbNombreCliente.Location = new Point(21, 134);
            txbNombreCliente.Name = "txbNombreCliente";
            txbNombreCliente.Size = new Size(554, 23);
            txbNombreCliente.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Location = new Point(21, 116);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 26;
            label5.Text = "Nombre Cliente:";
            // 
            // txbCodigoProducto
            // 
            txbCodigoProducto.Location = new Point(21, 80);
            txbCodigoProducto.Name = "txbCodigoProducto";
            txbCodigoProducto.Size = new Size(462, 23);
            txbCodigoProducto.TabIndex = 23;
            txbCodigoProducto.KeyDown += txbCodigoProducto_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(21, 62);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 22;
            label3.Text = "Código Producto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 19);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 21;
            label2.Text = "Nueva Venta";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(740, 340);
            label1.TabIndex = 20;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(58, 49, 69);
            label8.Location = new Point(592, 65);
            label8.Name = "label8";
            label8.Size = new Size(145, 97);
            label8.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Location = new Point(500, 369);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 28;
            label6.Text = "Cambio:";
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(58, 49, 69);
            label9.Font = new Font("Segoe UI", 18F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(629, 80);
            label9.Name = "label9";
            label9.Size = new Size(70, 32);
            label9.TabIndex = 41;
            label9.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.BackColor = Color.FromArgb(58, 49, 69);
            lblTotal.Font = new Font("Segoe UI", 18F);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(592, 116);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(145, 32);
            lblTotal.TabIndex = 42;
            lblTotal.Text = "0";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(21, 172);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.Size = new Size(716, 175);
            dgvDetalleVenta.TabIndex = 43;
            dgvDetalleVenta.CellContentClick += dgvDetalleVenta_CellContentClick;
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(lblTotal);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(btnRegistar);
            Controls.Add(btnBuscar);
            Controls.Add(txbPagoCon);
            Controls.Add(label7);
            Controls.Add(txbCambio);
            Controls.Add(label6);
            Controls.Add(txbNombreCliente);
            Controls.Add(label5);
            Controls.Add(txbCodigoProducto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVenta";
            Load += frmVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistar;
        private Button btnBuscar;
        private TextBox txbPagoCon;
        private Label label7;
        private TextBox txbCambio;
        private TextBox txbNombreCliente;
        private Label label5;
        private TextBox txbCodigoProducto;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label8;
        private Label label6;
        private Label label9;
        private Label lblTotal;
        private DataGridView dgvDetalleVenta;
    }
}