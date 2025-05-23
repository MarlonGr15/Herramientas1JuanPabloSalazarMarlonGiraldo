using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibros
{
    public class Servicios
    {
        private Tienda tienda;

        public Servicios(Tienda tienda)
        {
            this.Tienda = tienda;
        }

        internal Tienda Tienda { get => tienda; set => tienda = value; }


        public string CrearLibro(Libro libro)
        {
            Libro existente = BuscarLibro(libro.Isbn);
            if(existente != null)
            {
                return "ya existe el libro";
            }

            Tienda.Libros.Add(libro);
            return "libro creado";
        }

        public void EliminarLibro(int isbn)
        {
            Libro existente = BuscarLibro(isbn);
            if (existente == null)
            {
                Console.Write("no existe el libro");
                return;
            }

            Tienda.Libros.Remove(existente);
            Console.Write("se ha eliminado el libro");
        }


        public string RegistrarTransaccion(Libro libro, string tipo, int cantidad)
        {
            if (libro == null)
                return "Libro inválido.";

            Transaccion transaccion = new Transaccion(libro, tipo, DateTime.Now, cantidad);
            this.Tienda.Transacciones.Add(transaccion);
            return "Transacción registrada correctamente.";
        }

        public Libro BuscarLibro(int isbn)
        {
            foreach(Libro libro in Tienda.Libros)
            {
                if (libro.Isbn.Equals(isbn))
                {
                    return libro;
                }
            }

            return null;

        }


    }
}
