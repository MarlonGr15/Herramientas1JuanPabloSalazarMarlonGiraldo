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
    public partial class Consultas: Form
    {
        private Servicios servicio;
        public Consultas(Servicios servicio)
        {
            InitializeComponent();
            servicio = this.servicio;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Transacciones transaccion = new Transacciones(this.servicio);
            this.Hide();
            transaccion.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(this.servicio);
            this.Hide();
            inicio.Show();
        }
    }
}
