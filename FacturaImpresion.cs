using System;

namespace Solid
{
    public class FacturaImpresion : IFacturaImpresion
    {
        public void Imprimir(Factura factura)
        {
            Console.WriteLine("Factura:");
            Console.WriteLine($"Cantidad: {factura.Cantidad}");
            Console.WriteLine($"Nombre: {factura.Libro.Nombre}");
            Console.WriteLine($"Precio: {factura.Libro.Precio}");
            Console.WriteLine($"Descuento: {factura.TasaDescuento}");
            Console.WriteLine($"Impuesto: {factura.TasaImpuesto}");
            Console.WriteLine($"Total: {factura.Total}");
        }
    }
}
