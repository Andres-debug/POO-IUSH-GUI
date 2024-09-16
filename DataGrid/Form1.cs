using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid
{
    public partial class Form1 : Form
    {

        private List<Producto> productos;
        public Form1()
        {
            InitializeComponent();
            productos = new List<Producto>();


            dgvProductos.ColumnCount = 3;
            dgvProductos.Columns[0].Name = "Nombre";
            dgvProductos.Columns[1].Name = "Precio";
            dgvProductos.Columns[2].Name = "Cantidad";

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            if(txtNombre.Text =="" || txtPrecio.Text=="" || txtCantidad.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!decimal.TryParse(txtPrecio.Text, out decimal precio) || !int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, ingrese un valor numerico valido para el precio y la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                return;
            }

            Producto producto = new Producto(txtNombre.Text,precio,cantidad);

            productos.Add(producto);

            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();

            ActualizarTabla();

        }

        private void ActualizarTabla()
        {
            dgvProductos.Rows.Clear();

            foreach(var producto in productos)
            {
                string[] row = new string[]
                {
                    producto.Nombre,
                    producto.Precio.ToString("C"),
                    producto.Cantidad.ToString()
                };

                dgvProductos.Rows.Add(row);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
