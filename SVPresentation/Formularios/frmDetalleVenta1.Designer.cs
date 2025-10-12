namespace SVPresentation.Formularios
{
    partial class frmDetalleVenta1
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
            lblNumeroVenta = new Label();
            label1 = new Label();
            dgvDetalleVenta = new DataGridView();
            btnVerPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // lblNumeroVenta
            // 
            lblNumeroVenta.AutoSize = true;
            lblNumeroVenta.Location = new Point(120, 14);
            lblNumeroVenta.Name = "lblNumeroVenta";
            lblNumeroVenta.Size = new Size(13, 15);
            lblNumeroVenta.TabIndex = 18;
            lblNumeroVenta.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 17;
            label1.Text = "Número de venta:";
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(12, 43);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.Size = new Size(719, 264);
            dgvDetalleVenta.TabIndex = 16;
            // 
            // btnVerPDF
            // 
            btnVerPDF.BackColor = Color.White;
            btnVerPDF.Cursor = Cursors.Hand;
            btnVerPDF.FlatStyle = FlatStyle.Flat;
            btnVerPDF.Location = new Point(663, 14);
            btnVerPDF.Name = "btnVerPDF";
            btnVerPDF.Size = new Size(68, 23);
            btnVerPDF.TabIndex = 15;
            btnVerPDF.Text = "VerPDF";
            btnVerPDF.UseVisualStyleBackColor = false;
            btnVerPDF.Click += btnVerPDF_Click;
            // 
            // frmDetalleVenta1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(743, 321);
            Controls.Add(lblNumeroVenta);
            Controls.Add(label1);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(btnVerPDF);
            MaximizeBox = false;
            MaximumSize = new Size(759, 360);
            MinimizeBox = false;
            MinimumSize = new Size(759, 360);
            Name = "frmDetalleVenta1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle Venta ";
            Load += frmDetalleVenta1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumeroVenta;
        private Label label1;
        private DataGridView dgvDetalleVenta;
        private Button btnVerPDF;
    }
}