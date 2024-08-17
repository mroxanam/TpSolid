namespace Solid
{
    public class Factura
    {
        public Libro Libro { get; }
        public int Cantidad { get; }
        public double TasaDescuento { get; }
        public double TasaImpuesto { get; }
        public double Total { get; }

        public Factura(Libro libro, int cantidad, double tasaDescuento, double tasaImpuesto)
        {
            Libro = libro;
            Cantidad = cantidad;
            TasaDescuento = tasaDescuento;
            TasaImpuesto = tasaImpuesto;
            Total = CalcularTotal();
        }

        private double CalcularTotal()
        {
            double subtotal = Libro.Precio * Cantidad;
            double descuento = subtotal * TasaDescuento;
            double impuesto = subtotal * TasaImpuesto;
            return subtotal - descuento + impuesto;
        }
    }
}
