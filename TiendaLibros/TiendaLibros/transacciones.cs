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
    public partial class Transacciones: Form
    {

        private Servicios servicio;
        public Transacciones(Servicios servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }

        //transacciones por abastecimiento
        private void label12_Click(object sender, EventArgs e)
        {
            var abastecimientos = servicio.Tienda.Transacciones.Where(t => t.TipoTransaccion == "Abastecimiento").ToList();
            MostrarTransacciones(abastecimientos);
        }

        private void MostrarTransacciones(List<Transaccion> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }
        //transacciones por venta
        private void label11_Click(object sender, EventArgs e)
        {
            var ventas = servicio.Tienda.Transacciones.Where(t => t.TipoTransaccion == "Venta").ToList();
            MostrarTransacciones(ventas);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarTransacciones(this.servicio.Tienda.Transacciones);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(this.servicio);
            this.Hide();
            inicio.Show();
            
        }
    }
}
