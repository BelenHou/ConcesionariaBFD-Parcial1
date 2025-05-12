using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;
using Model.Clases;

namespace WindowsFormsApp
{
    public partial class ComprobantesControl : UserControl
    {
        private ComprobanteController comprobanteController;
        private int idEmpleadoActual;
        private string puestoActual;

        public ComprobantesControl(int idEmpleado, string puesto)
        {
            InitializeComponent();
            comprobanteController = new ComprobanteController();
            idEmpleadoActual = idEmpleado;
            puestoActual = puesto;

            // Llenamos el ComboBox con "compra" y "venta"

            comboBox1.Items.Add("compra");
            comboBox1.Items.Add("venta");
            comboBox1.SelectedIndex = -1;  // Inicialmente no hay nada seleccionado

            // Configuración inicial del dateTimePicker(FechaHora)
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Checked = false; // Sin filtro de fecha al inicio

            CargarComprobantes();  // Cargar todos los comprobantes al inicio
        }
        
        //Botón para volver a gerenteControl
        private void BtnIrAGerente_Click(object sender, EventArgs e)
        {
            this.Hide();
            GerenteControl gerenteControl = new GerenteControl(idEmpleadoActual, puestoActual);
            gerenteControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(gerenteControl);
            gerenteControl.BringToFront();
        }


        // Método para filtrar comprobantes por tipo y fecha
        private void CargarComprobantes(string tipo = null, DateTime? fecha = null)
        {
            var comprobantes = comprobanteController.ObtenerTodosLosComprobantes();

            if (!string.IsNullOrEmpty(tipo))
            {
                comprobantes = comprobantes.FindAll(c => c.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase));
            }

            if (fecha.HasValue)
            {
                comprobantes = comprobantes.FindAll(c => c.FechaHora.Date == fecha.Value.Date);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = comprobantes;
        }

        // Botón para filtrar comprobante 
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string tipo = comboBox1.SelectedItem?.ToString();
            DateTime? fecha = dateTimePicker1.Checked ? dateTimePicker1.Value : (DateTime?)null;

            CargarComprobantes(tipo, fecha);
        }

        // Botón para limpiar los filtros
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Checked = false;

            CargarComprobantes();
        }

        // Para seleccionar el tipo de comprobante
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = comboBox1.SelectedItem?.ToString();
            DateTime? fecha = dateTimePicker1.Checked ? dateTimePicker1.Value : (DateTime?)null;

            CargarComprobantes(tipo, fecha);
        }
        
        // Para seleccionar la fecha 
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string tipo = comboBox1.SelectedItem?.ToString();
            DateTime? fecha = dateTimePicker1.Checked ? dateTimePicker1.Value : (DateTime?)null;

            CargarComprobantes(tipo, fecha);
        }
    }
}
