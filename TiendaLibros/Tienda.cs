using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibros
{
    class Tienda
    {
        private List<Libro> libros;
        private List<Transaccion> transacciones;

        public Tienda(List<Libro> libros, List<Transaccion> transacciones)
        {
            this.Libros = libros;
            this.Transacciones = transacciones;
        }

        internal List<Libro> Libros { get => libros; set => libros = value; }
        internal List<Transaccion> Transacciones { get => transacciones; set => transacciones = value; }
    }
}
