using System.IO;

namespace Solid
{
    public class FacturaPersistencia : IFacturaPersistencia
    {
        public void Guardar(Factura factura, string nombreArchivo)
        {
            using (StreamWriter writer = new StreamWriter(nombreArchivo))
            {
                writer.WriteLine($"Cantidad: {factura.Cantidad}");
                writer.WriteLine($"Nombre: {factura.Libro.Nombre}");
                writer.WriteLine($"Precio: {factura.Libro.Precio}");
                writer.WriteLine($"Descuento: {factura.TasaDescuento}");
                writer.WriteLine($"Impuesto: {factura.TasaImpuesto}");
                writer.WriteLine($"Total: {factura.Total}");
            }
        }
    }
}

