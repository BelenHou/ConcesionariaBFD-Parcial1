using System;
using System.Collections.Generic;
using System.Windows.Forms;
using concesionario;
using Controller;
using Model.Clases;

namespace WindowsFormsApp
{
    public partial class GerenteControl : UserControl
    {
        private AutoController autoController;
        private List<Auto> autosDisponibles;
        public int idEmpleadoActual; // ID del empleado actual 
        public string puestoActual; // Puesto del empleado actual 

        public GerenteControl(int idEmpleado, string puesto)
        {
            InitializeComponent();
            autoController = new AutoController();
            idEmpleadoActual = idEmpleado; // Guardar el ID del empleado actual
            puestoActual = puesto;
            CargarAutosDisponibles();
            ConfigurarDataGridView();
            if (puestoActual.ToLower() != "gerente")
            {
                btnAgregar.Visible = false;
            }
        }

       
        
        private void GerenteControl_Load(object sender, EventArgs e)
        {
            CargarAutosDisponibles();
            
        }

        // Método para cargar los autos disponibles
        private void CargarAutosDisponibles()
        {
            autosDisponibles = autoController.BuscarAutosPorEstado("disponible");
            dataGridViewAutos.DataSource = null;
            dataGridViewAutos.DataSource = autosDisponibles;
        }

        // Configuramos el DataGridView con botones para "Vender" y "Modificar Precio"
        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            dataGridViewAutos.DataSource = null;
            dataGridViewAutos.DataSource = autosDisponibles;

            // Agregar botón "Vender"
            if (!dataGridViewAutos.Columns.Contains("btnVender"))
            {
                var btnVender = new DataGridViewButtonColumn
                {
                    Name = "btnVender",
                    HeaderText = "Vender",
                    Text = "Vender",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewAutos.Columns.Add(btnVender);
            }

            // Agregar botón "Modificar Precio"
            if (!dataGridViewAutos.Columns.Contains("btnModificarPrecio"))
            {
                var btnModificarPrecio = new DataGridViewButtonColumn
                {
                    Name = "btnModificarPrecio",
                    HeaderText = "Modificar Precio",
                    Text = "Modificar",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewAutos.Columns.Add(btnModificarPrecio);
            }

            dataGridViewAutos.CellClick += DataGridViewAutos_CellClick;
        }

        // Manejar eventos de click en el DataGridView
        private void DataGridViewAutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya hecho clic en una fila válida
            if (e.RowIndex >= 0 && e.RowIndex < autosDisponibles.Count)
            {
                var autoSeleccionado = autosDisponibles[e.RowIndex];

                // Click en botón "Vender"
                if (dataGridViewAutos.Columns[e.ColumnIndex].Name == "btnVender")
                {
                    VenderAuto(autoSeleccionado);

                    // Actualizar directamente el DataGridView después de vender
                    dataGridViewAutos.DataSource = null;
                    dataGridViewAutos.DataSource = autosDisponibles;
                }
                // Click en botón "Modificar Precio"
                else if (dataGridViewAutos.Columns[e.ColumnIndex].Name == "btnModificarPrecio")
                {
                    ModificarPrecioAuto(autoSeleccionado);

                    // Actualizar por si el precio cambió
                    dataGridViewAutos.DataSource = null;
                    dataGridViewAutos.DataSource = autosDisponibles;
                }
            }
        }


        // Llamar al método AgregarAuto
        public void btnAgregarAuto_Click(object sender, EventArgs e)
        {   
            string marca = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la marca del auto:", "Agregar Auto", "");
            if (string.IsNullOrEmpty(marca)) return; // Si se cancela, no continuar

            string modelo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el modelo del auto:", "Agregar Auto", "");
            if (string.IsNullOrEmpty(modelo)) return; // Si se cancela, no continuar

            string color = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el color del auto:", "Agregar Auto", "");
            if (string.IsNullOrEmpty(color)) return; // Si se cancela, no continuar

            string patente = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la patente del auto:", "Agregar Auto", "");
            if (string.IsNullOrEmpty(patente)) return; // Si se cancela, no continuar

            string anioStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el año del auto:", "Agregar Auto", "");
            if (string.IsNullOrEmpty(anioStr)) return; // Si se cancela, no continuar

            string precioStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio del auto:", "Agregar Auto", "");
            if (string.IsNullOrEmpty(precioStr)) return; // Si se cancela, no continuar

            // Validación de datos
            if (!int.TryParse(anioStr, out int anio) || !decimal.TryParse(precioStr, out decimal precio))
            {
                MessageBox.Show("Datos inválidos. Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nuevoAuto = new Auto
            {
                Marca = marca,
                Modelo = modelo,
                Color = color,
                Patente = patente,
                Anio = anio,
                Estado = "disponible",
                ID_empleado = idEmpleadoActual,
                Precio = precio
            };

            if (autoController.AgregarAuto(nuevoAuto, new Empleados { ID_empleado = idEmpleadoActual, Puesto = "Gerente" }))
            {
                MessageBox.Show("El auto fue agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAutosDisponibles();
            }
            else
            {
                MessageBox.Show("Error al agregar el auto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llamar al método BuscarAuto
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(criterio))
            {
                autosDisponibles = autoController.BuscarAuto(criterio);
            }
            else
            {
                autosDisponibles = autoController.BuscarAutosPorEstado("disponible");
            }

            dataGridViewAutos.DataSource = null;
            dataGridViewAutos.DataSource = autosDisponibles;
        }

        // Llamar al método VenderAuto
        private void VenderAuto(Auto autoSeleccionado)
        {
            var confirmResult = MessageBox.Show($"¿Está seguro de que desea vender el auto {autoSeleccionado.Marca} {autoSeleccionado.Modelo}?",
                                                "Confirmar Venta",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (autoController.VenderAuto(autoSeleccionado.ID_auto, idEmpleadoActual, "Venta realizada"))
                {
                    MessageBox.Show($"El auto {autoSeleccionado.Marca} {autoSeleccionado.Modelo} fue vendido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAutosDisponibles();
                }
                else
                {
                    MessageBox.Show("Error al vender el auto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
      

        // Llamar al método ActualizarPrecioAuto
        private void ModificarPrecioAuto(Auto autoSeleccionado)
        {
            string nuevoPrecioStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo precio del auto:", "Modificar Precio", autoSeleccionado.Precio.ToString());
            if (decimal.TryParse(nuevoPrecioStr, out decimal nuevoPrecio))
            {
                if (autoController.ActualizarPrecioAuto(autoSeleccionado.ID_auto, nuevoPrecio))
                {
                    MessageBox.Show($"El precio del auto {autoSeleccionado.Marca} {autoSeleccionado.Modelo} fue actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAutosDisponibles();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el precio del auto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El precio ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //boton para ir a Comprobantes 
        private void btnComprobantes_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ocultar el GerenteControl actual
            
            ComprobantesControl comprobantesControl = new ComprobantesControl(idEmpleadoActual,puestoActual);// Crear una instancia del control de comprobantes
            comprobantesControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(comprobantesControl); // Añadir el ServicioControl
            comprobantesControl.BringToFront(); // Traer el ServicioControl al frente
        }

        //boton para ir a servicios 
        private void BtnIrAServicio_Click(object sender, EventArgs e)
        {
            // Cambiar de GerenteControl a ServicioControl
            this.Hide(); // Ocultar el GerenteControl actual
            ServicioControl servicioControl = new ServicioControl(idEmpleadoActual, puestoActual); // Crear una nueva instancia de ServicioControl
            servicioControl.Dock = DockStyle.Fill;  
            this.Parent.Controls.Add(servicioControl); // Añadir el ServicioControl
            servicioControl.BringToFront(); // Traer el ServicioControl al frente
        }
    }


}
