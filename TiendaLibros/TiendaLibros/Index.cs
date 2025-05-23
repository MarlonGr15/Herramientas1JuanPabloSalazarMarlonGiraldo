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
    public partial class Index: Form
    {
        private Servicios servicio;
        public Index()
        {
            InitializeComponent();
            this.servicio = new Servicios(new Tienda(new List<Libro>(), new List<Transaccion>()));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(this.servicio);
            this.Hide();
            inicio.Show();
        }
    }
}
