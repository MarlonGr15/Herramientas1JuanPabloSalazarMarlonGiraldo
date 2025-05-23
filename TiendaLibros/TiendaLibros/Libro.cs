using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibros
{
    public class Libro
    {
        private int isbn;
        private string titulo;
        private double precioCompra;
        private double precioVenta;
        private int cantidadActual;

        public Libro(int isbn, string titulo, double precioCompra, double precioVenta, int cantidadActual)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.cantidadActual = cantidadActual;
        }

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public double PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int CantidadActual { get => cantidadActual; set => cantidadActual = value; }
    }
}
