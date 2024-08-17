using System;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un libro y una factura
            Libro libro = new Libro("El Gran Libro", "Autor Ejemplo", 2024, 29, "1234567890");
            Factura factura = new Factura(libro, 2, 0.1, 0.2);

            // Usar las clases de impresión y persistencia
            IFacturaImpresion impresion = new FacturaImpresion();
            IFacturaPersistencia persistencia = new FacturaPersistencia();

            // Imprimir la factura
            impresion.Imprimir(factura);

            // Guardar la factura en un archivo
            persistencia.Guardar(factura, "factura.txt");

            // Confirmar que se ha guardado
            Console.WriteLine("Factura guardada correctamente en 'factura.txt'.");
        }
    }
}
