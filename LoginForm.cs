using System;
using System.Windows.Forms;
using Controller;
using Model.Clases;
using System.Data.SqlClient;
using DataBase;

namespace WindowsFormsApp
{
    public partial class LoginForm : Form
    {
        private readonly LoginController loginController;
        private readonly DataBaseConnection dbConnection;

        public LoginForm()
        {
            InitializeComponent();
            loginController = new LoginController();

            // Configuración para iniciar el formulario maximizado (como cuando se toca "maximizar")
            this.WindowState = FormWindowState.Normal;  // Establecer la ventana maximizada
            // FormBorderStyle no se cambia, así se mantiene la barra de título y bordes
        }

        //boton para iniciar sesion (acceder)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar credenciales
            var resultado = loginController.ValidarCredenciales(usuario, contraseña);
            string puesto = resultado.Puesto;
            int idEmpleado = resultado.IdEmpleado;

            if (puesto == "Gerente")
            {
                MessageBox.Show("Bienvenido, Gerente.", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUserControl(new GerenteControl(idEmpleado, puesto));

            }
            else if (puesto == "Empleado")
            {
                MessageBox.Show("Bienvenido, Empleado.", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUserControl(new GerenteControl(idEmpleado, puesto)); 
            
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUserControl(UserControl control)
        {
            this.Controls.Clear(); // Limpiar los controles actuales del formulario
            control.Dock = DockStyle.Fill; // Ajustar el UserControl al tamaño del formulario
            this.Controls.Add(control); // Agregar el UserControl al formulario
        }
    }
}
