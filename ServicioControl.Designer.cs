namespace WindowsFormsApp
{
    partial class ServicioControl
    {

        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnServicionew = new System.Windows.Forms.Button();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.BtnRegresarAGerente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnServicionew
            // 
            this.BtnServicionew.Location = new System.Drawing.Point(754, 516);
            this.BtnServicionew.Name = "BtnServicionew";
            this.BtnServicionew.Size = new System.Drawing.Size(200, 38);
            this.BtnServicionew.TabIndex = 1;
            this.BtnServicionew.Text = "Agregar servicio";
            this.BtnServicionew.UseVisualStyleBackColor = true;
            this.BtnServicionew.Click += new System.EventHandler(this.BtnServicionew_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Location = new System.Drawing.Point(51, 57);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.RowHeadersWidth = 62;
            this.dgvServicios.RowTemplate.Height = 28;
            this.dgvServicios.Size = new System.Drawing.Size(1037, 453);
            this.dgvServicios.TabIndex = 2;
            this.dgvServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellClick);
            // 
            // BtnRegresarAGerente
            // 
            this.BtnRegresarAGerente.Location = new System.Drawing.Point(89, 520);
            this.BtnRegresarAGerente.Name = "BtnRegresarAGerente";
            this.BtnRegresarAGerente.Size = new System.Drawing.Size(135, 34);
            this.BtnRegresarAGerente.TabIndex = 3;
            this.BtnRegresarAGerente.Text = "Volver";
            this.BtnRegresarAGerente.UseVisualStyleBackColor = true;
            this.BtnRegresarAGerente.Click += new System.EventHandler(this.BtnRegresarAGerente_Click);
            // 
            // ServicioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.BtnRegresarAGerente);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.BtnServicionew);
            this.Name = "ServicioControl";
            this.Size = new System.Drawing.Size(1142, 621);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnServicionew;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.Button BtnRegresarAGerente;
    }
}
