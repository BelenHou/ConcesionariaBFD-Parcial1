using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Controller;  
using Model.Clases;  

namespace WindowsFormsApp
{

    public partial class ServicioControl : UserControl
    {
        private ServicioController servicioController;

        private int idEmpleadoActual;
        private string puestoActual;
        public ServicioControl(int idEmpleado, string puesto)
        {
            InitializeComponent();
            servicioController = new ServicioController();
            idEmpleadoActual = idEmpleado;
            puestoActual = puesto;
            CargarServicios();
 
        }

        // boton para regresar al menu de gerente
        private void BtnRegresarAGerente_Click(object sender, EventArgs e)
        {
            this.Hide();  // Ocultar el ServicioControl
            GerenteControl gerenteControl = new GerenteControl(idEmpleadoActual,puestoActual);  // Crear una nueva instancia de GerenteControl
            gerenteControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(gerenteControl);
            gerenteControl.BringToFront();  // Mostrar el GerenteControl
        }

        // Método para cargar los servicios desde la base de datos
        private void CargarServicios()
        {
            // Obtener la lista de servicios desde el controlador
            var servicios = servicioController.ObtenerTodosLosServicios();

            // Asignar la lista de servicios al DataGridView
            dgvServicios.DataSource = servicios;
            AgregarBotonesAccion();
        }

        // Método para agregar botones al DataGridView
        private void AgregarBotonesAccion()
        {
            if (!dgvServicios.Columns.Contains("btnEliminarServicio"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                {
                    Name = "btnEliminarServicio",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                dgvServicios.Columns.Add(btnEliminar);
            }

            if (!dgvServicios.Columns.Contains("btnMarcarRealizado"))
            {
                DataGridViewButtonColumn btnRealizado = new DataGridViewButtonColumn
                {
                    Name = "btnMarcarRealizado",
                    HeaderText = "Realizado",
                    Text = "Realizado",
                    UseColumnTextForButtonValue = true
                };
                dgvServicios.Columns.Add(btnRealizado);
            }

        }


        // Método para manejar el click en el botón de "Nuevo Servicio"
        private void BtnServicionew_Click(object sender, EventArgs e)
        {
            // Solicitar datos del servicio
            string descripcion = Microsoft.VisualBasic.Interaction.InputBox("Ingrese servicio a realizar y nombre del cliente:", "Nuevo Servicio", "");
            if (string.IsNullOrEmpty(descripcion)) return; // Si se cancela, no continuar

            string fechaStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la fecha de turno del servicio (formato: dd/mm/yyyy):", "Nuevo Servicio", "");
            if (string.IsNullOrEmpty(fechaStr)) return; // Si se cancela, no continuar

            // Validación de la fecha
            if (!DateTime.TryParse(fechaStr, out DateTime fecha))
            {
                MessageBox.Show("La fecha ingresada no es válida. Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el ID del empleado 
            int idEmpleado = ObtenerIDEmpleado();  

            // Crear el objeto servicio con los datos proporcionados
            Servicio nuevoServicio = new Servicio
            {
                Descripcion = descripcion,
                Fecha = fecha,
                Estado = "En proceso", // Estado predeterminado
                ID_empleado = idEmpleado
            };

            // Agregar el servicio usando el controlador
            bool exito = servicioController.AgregarServicio(nuevoServicio);

            // Mostrar mensaje dependiendo del éxito
            if (exito)
            {
                MessageBox.Show("Servicio agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar la lista de servicios
                CargarServicios();
            }
            else
            {
                MessageBox.Show("Error al agregar el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obtener el ID del empleado
        private int ObtenerIDEmpleado()
        {
            
            return idEmpleadoActual; 
        }

        // Evento para marcar un servicio como "Realizado"
        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idServicio = Convert.ToInt32(dgvServicios.Rows[e.RowIndex].Cells["ID_servicio"].Value);

                if (dgvServicios.Columns[e.ColumnIndex].Name == "btnEliminarServicio")
                {
                    var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este servicio?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        if (servicioController.EliminarServicio(idServicio))
                            MessageBox.Show("Eliminado correctamente");
                        else
                            MessageBox.Show("Error al eliminar");

                        CargarServicios();
                    }
                    else
                    {

                    }
                }
                else if (dgvServicios.Columns[e.ColumnIndex].Name == "btnMarcarRealizado")
                {
                    if (servicioController.MarcarComoRealizado(idServicio))
                        MessageBox.Show("Servicio marcado como realizado.");
                    else
                        MessageBox.Show("Error al marcar como realizado.");

                    CargarServicios();
                }
            }
        }

    }
}
