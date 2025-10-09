namespace SVPresentation.Formularios
{
    partial class frmBuscarProductos
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
            dgvProductos = new DataGridView();
            btnBuscar = new Button();
            txbBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 43);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(719, 264);
            dgvProductos.TabIndex = 10;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(663, 14);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(68, 23);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txbBuscar
            // 
            txbBuscar.Location = new Point(12, 14);
            txbBuscar.Name = "txbBuscar";
            txbBuscar.Size = new Size(645, 23);
            txbBuscar.TabIndex = 8;
            // 
            // frmBuscarProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(743, 321);
            Controls.Add(dgvProductos);
            Controls.Add(btnBuscar);
            Controls.Add(txbBuscar);
            MaximizeBox = false;
            MaximumSize = new Size(759, 360);
            MinimizeBox = false;
            MinimumSize = new Size(759, 360);
            Name = "frmBuscarProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscarProductos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnBuscar;
        private TextBox txbBuscar;
    }
}