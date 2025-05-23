using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibros
{
    class Transaccion
    {
        private Libro libro;
        private string tipoTransaccion;
        private DateTime fecha;
        private int cantidadEjemplares;

        public Transaccion(Libro libro, string tipoTransaccion, DateTime fecha, int cantidadEjemplares)
        {
            this.Libro = libro;
            this.TipoTransaccion = tipoTransaccion;
            this.Fecha = fecha;
            this.CantidadEjemplares = cantidadEjemplares;
        }

        public string TipoTransaccion { get => tipoTransaccion; set => tipoTransaccion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int CantidadEjemplares { get => cantidadEjemplares; set => cantidadEjemplares = value; }
        internal Libro Libro { get => libro; set => libro = value; }
    }
}
