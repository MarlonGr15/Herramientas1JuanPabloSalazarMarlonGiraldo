using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibros
{
    class Servicios
    {
        private Tienda tienda;

        public Servicios(Tienda tienda)
        {
            this.Tienda = tienda;
        }

        internal Tienda Tienda { get => tienda; set => tienda = value; }


        public void CrearLibro(Libro libro)
        {
            Libro existente = BuscarLibro(libro.Isbn);
            if(existente != null)
            {
                Console.Write("ya existe el libro");
                return;
            }

            Tienda.Libros.Add(libro);
            Console.Write("libro creado");
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


        public void RegistrarVenta()
        {

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
