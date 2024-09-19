using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid
{
    public partial class Form1 : Form
    {

        private List<Producto> productos;
        private const string archivoProducto = "productos.txt";
        public Form1()
        {
            InitializeComponent();
            productos = new List<Producto>();

            dgvProductos.ColumnCount = 3;
            dgvProductos.Columns[0].Name = "Nombre";
            dgvProductos.Columns[1].Name = "Precio";
            dgvProductos.Columns[2].Name = "Cantidad";

            CargarProductosDesdeArchivo();

        

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            var productosFiltrados = productos.Where(p=> p.Nombre.ToLower().Contains(filtro)).ToList();

            ActualizarTabla(productosFiltrados);
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

            GuardarProductoEnArchivo(producto);

            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();

            ActualizarTabla(productos);

        }

        private void GuardarProductoEnArchivo (Producto producto)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivoProducto, true))
                {
                    writer.WriteLine(producto.ToString());
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo: " + ex.Message);
            }
        }

        private void CargarProductosDesdeArchivo()
        {
            if (File.Exists(archivoProducto))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(archivoProducto)) {

                        string linea;
                        while ((linea=reader.ReadLine()) != null)
                        {
                            string[] datos = linea.Split(',');

                            Producto producto = new Producto(datos[0], decimal.Parse(datos[1]), int.Parse(datos[2]));
                            productos.Add(producto);

                        }

                    }

                    ActualizarTabla (productos);


                }catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                }
            }
        }





        private void ActualizarTabla(List<Producto> listaProductos)
        {
            dgvProductos.Rows.Clear();

            foreach(var producto in listaProductos)
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
        private Producto productoSeleccionado;
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                txtNombre.Text = row.Cells[0].Value.ToString();
                txtPrecio.Text = row.Cells[1].Value.ToString();
                txtCantidad.Text = row.Cells[2].Value.ToString();

                productoSeleccionado = productos[e.RowIndex];
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if(productoSeleccionado != null)
            {
                productoSeleccionado.Nombre = txtNombre.Text;
                productoSeleccionado.Precio = decimal.Parse(txtPrecio.Text);
                productoSeleccionado.Cantidad = int.Parse(txtCantidad.Text);

                GuardarTodosLosProductosEnArchivo();
                ActualizarTabla(productos);

                MessageBox.Show("Producto Editado Exitosamente");
            }
        }

        private void GuardarTodosLosProductosEnArchivo()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivoProducto, false))
                {
                    foreach(var producto in productos)
                    {
                        writer.WriteLine(producto.ToString());
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error al guardar en Archivo" + ex.Message);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if(productoSeleccionado != null)
            {
                productos.Remove(productoSeleccionado);

                GuardarTodosLosProductosEnArchivo();
                ActualizarTabla(productos);

                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();

                MessageBox.Show("Producto Eliminado");
            }
        }
    }
}
