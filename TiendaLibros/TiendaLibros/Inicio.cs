using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaLibros
{
    public partial class Inicio: Form
    {

        private Servicios servicio;
        private int indiceSeleccionado = -1;
        public Inicio()
        {
            InitializeComponent();
            this.servicio = new Servicios(new Tienda(new List<Libro>(), new List<Transaccion>()));
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MostrarLibros()
        {
            dataGridView1.DataSource = null; // Limpiar anterior
            dataGridView1.DataSource = this.servicio.Tienda.Libros; // Asignar lista
        }

        private void label10_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Id.Text) ||
            string.IsNullOrWhiteSpace(Titulo.Text) ||
            string.IsNullOrWhiteSpace(PrecioC.Text) ||
            string.IsNullOrWhiteSpace(PrecioV.Text) ||
            string.IsNullOrWhiteSpace(Cantidad.Text))
            {
                MessageBox.Show("Todos los campos son requeridos");
                return;
            }

            try
            {
                int isbn = int.Parse(Id.Text);
                string titulo = Titulo.Text;
                double precioC = double.Parse(PrecioC.Text);
                double precioV = double.Parse(PrecioV.Text);
                int cantidad = int.Parse(Cantidad.Text);

                Libro libro = new Libro(isbn, titulo, precioC, precioV, cantidad);
                MessageBox.Show(this.servicio.CrearLibro(libro));
                MostrarLibros();
                LimpiarCampos();
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese valores válidos en los campos numéricos.");
            }
            

            
        }

        private void LimpiarCampos()
        {
            Id.ResetText();
            Titulo.ResetText();
            PrecioC.ResetText();
            PrecioV.ResetText();
            Cantidad.ResetText();
        }

        private void Cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void Titulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                Libro libroSeleccionado = (Libro)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                Id.Text = libroSeleccionado.Isbn.ToString();
                Titulo.Text = libroSeleccionado.Titulo;
                PrecioC.Text = libroSeleccionado.PrecioCompra.ToString();
                PrecioV.Text = libroSeleccionado.PrecioVenta.ToString();
                Cantidad.Text = libroSeleccionado.CantidadActual.ToString();
            }

            indiceSeleccionado = e.RowIndex;
        }

        //metodo para abastecer libro
        private void label11_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado >= 0)
            {
                Libro libro = this.servicio.Tienda.Libros[indiceSeleccionado];
                
                if(int.Parse(Cantidad.Text) > libro.CantidadActual)
                {
                    int temporal = int.Parse(Cantidad.Text) - libro.CantidadActual;
                    libro.CantidadActual = int.Parse(Cantidad.Text);
                    this.servicio.RegistrarTransaccion(libro, "Abastecimiento", temporal);
                }
                else { MessageBox.Show("Solo se puede modificar la cantidad y debe ser mayor a la actual"); }

                    MostrarLibros();
                LimpiarCampos();
            }
        }

        //metodo para la venta de libro
        private void label12_Click(object sender, EventArgs e)
        {
            if(indiceSeleccionado >= 0)
            {
                Libro libro = this.servicio.Tienda.Libros[indiceSeleccionado];

                if (libro.CantidadActual > 0)
                {
                     
                    libro.CantidadActual -= 1;
                    this.servicio.RegistrarTransaccion(libro, "Venta", 1);
                    MessageBox.Show("Venta realizada exitosamente");
                    MostrarLibros();
                    LimpiarCampos();

                }
                else { MessageBox.Show("No hay ejemplares disponibles"); }
            }
            else
            {
                MessageBox.Show("Seleccione un libro de la tabla para generar la venta");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Transacciones ventanaTransacciones = new Transacciones(this.servicio);
            this.Hide();
            ventanaTransacciones.Show();
        }
    }
}
