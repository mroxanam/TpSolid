namespace Solid
{
    public class Libro
    {
        public string Nombre { get; }
        public string Autor { get; }
        public int A�o { get; }
        public double Precio { get; }
        public string ISBN { get; }

        public Libro(string nombre, string autor, int a�o, double precio, string isbn)
        {
            Nombre = nombre;
            Autor = autor;
            A�o = a�o;
            Precio = precio;
            ISBN = isbn;
        }
    }
}

