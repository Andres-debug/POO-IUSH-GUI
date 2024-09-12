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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxUser.Text;
            string password = textBoxPassword.Text;

            Usuario usuario = BaseDeDatosFalsaHelpers.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == password);
            
            if(usuario != null)
            {
                MessageBox.Show("!Login Exitoso!");

            }
            else
            {
                MessageBox.Show("Nombre de Usuario o Contraseña Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 formRegistro = new Form3();
            formRegistro.Show();
        }
    }
}
