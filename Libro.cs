namespace Solid
{
    public class Libro
    {
        public string Nombre { get; }
        public string Autor { get; }
        public int Año { get; }
        public double Precio { get; }
        public string ISBN { get; }

        public Libro(string nombre, string autor, int año, double precio, string isbn)
        {
            Nombre = nombre;
            Autor = autor;
            Año = año;
            Precio = precio;
            ISBN = isbn;
        }
    }
}

