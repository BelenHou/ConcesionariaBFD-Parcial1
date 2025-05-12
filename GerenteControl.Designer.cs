using System;

using System.Windows.Forms;

namespace WindowsFormsApp
{
    partial class GerenteControl
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
            this.dataGridViewAutos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnComprobantes = new System.Windows.Forms.Button();
            this.BtnIrAServicio = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAutos
            // 
            this.dataGridViewAutos.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridViewAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutos.Location = new System.Drawing.Point(89, 18);
            this.dataGridViewAutos.Name = "dataGridViewAutos";
            this.dataGridViewAutos.RowHeadersWidth = 62;
            this.dataGridViewAutos.RowTemplate.Height = 28;
            this.dataGridViewAutos.Size = new System.Drawing.Size(988, 454);
            this.dataGridViewAutos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(510, 478);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(214, 52);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar auto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregarAuto_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(186, 491);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(278, 26);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnComprobantes
            // 
            this.btnComprobantes.Location = new System.Drawing.Point(730, 479);
            this.btnComprobantes.Name = "btnComprobantes";
            this.btnComprobantes.Size = new System.Drawing.Size(224, 52);
            this.btnComprobantes.TabIndex = 4;
            this.btnComprobantes.Text = "Comprobantes";
            this.btnComprobantes.UseVisualStyleBackColor = true;
            this.btnComprobantes.Click += new System.EventHandler(this.btnComprobantes_Click);
            // 
            // BtnIrAServicio
            // 
            this.BtnIrAServicio.Location = new System.Drawing.Point(960, 479);
            this.BtnIrAServicio.Name = "BtnIrAServicio";
            this.BtnIrAServicio.Size = new System.Drawing.Size(157, 53);
            this.BtnIrAServicio.TabIndex = 5;
            this.BtnIrAServicio.Text = "Turnos Service";
            this.BtnIrAServicio.UseVisualStyleBackColor = true;
            this.BtnIrAServicio.Click += new System.EventHandler(this.BtnIrAServicio_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.White;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBuscar.Location = new System.Drawing.Point(85, 494);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(93, 20);
            this.lblBuscar.TabIndex = 6;
            this.lblBuscar.Text = "BUSCAR :";
            // 
            // GerenteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.BtnIrAServicio);
            this.Controls.Add(this.btnComprobantes);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dataGridViewAutos);
            this.Name = "GerenteControl";
            this.Size = new System.Drawing.Size(1142, 621);
            this.Load += new System.EventHandler(this.GerenteControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAutos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
        private Button btnComprobantes;
        private Button BtnIrAServicio;
        private Label lblBuscar;
    }
}
