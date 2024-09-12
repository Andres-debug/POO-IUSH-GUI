using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsClase1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxUserName.Text;
            string contraseña = textBoxPassword.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña)) {

                MessageBox.Show("Por favor, ingresa un nombre de usuario y una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool usuarioExiste = BaseDeDatosFalsaHelpers.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);

            if (usuarioExiste) {

                MessageBox.Show("Este nombre de usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Usuario nuevoUsuario = new Usuario(nombreUsuario, contraseña);
                BaseDeDatosFalsaHelpers.Usuarios.Add(nuevoUsuario);
                MessageBox.Show("Registro Exitoso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        
        
        }
    }
}
