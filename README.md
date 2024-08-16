# TpSolid
practicas
[Los principios SOLID de programación orientada a objetos explicados en Español sencillo.pdf](https://github.com/user-attachments/files/16642562/Los.principios.SOLID.de.programacion.orientada.a.objetos.explicados.en.Espanol.sencillo.pdf)
Veremos el código de un programa simple de facturación de librería como ejemplo. Comencemos definiendo una clase de libro para usar en nuestra factura.

class Libro {
	String nombre;
	String nombreAutor;
	int anyo;
	int precio;
	String isbn;

	public Libro(String nombre, String nombreAutor, int anyo, int precio, String isbn) {
		this.nombre = nombre;
		this.nombreAutor = nombreAutor;
		this.anyo = anyo;
        this.precio = precio;
		this.isbn = isbn;
	}
}
Esta es una clase de libro simple con algunos campos. Nada sofisticado. No estoy haciendo que los campos sean privados para que no tengamos que lidiar con getters y setters y podamos centrarnos en la lógica.

Ahora vamos a crear la clase de factura que contendrá la lógica para crear la factura y calcular el precio total. Por ahora, suponga que nuestra librería solo vende libros y nada más.

public class Factura {

	private Libro libro;
	private int cantidad;
	private double tasaDescuento;
	private double tasaImpuesto;
	private double total;

	public Factura(Libro libro, int cantidad, double tasaDescuento, double tasaImpuesto) {
		this.libro = libro;
		this.cantidad = cantidad;
		this.tasaDescuento = tasaDescuento;
		this.tasaImpuesto = tasaImpuesto;
		this.total = this.calculaTotal();
	}

	public double calculaTotal() {
	        double precio = ((libro.precio - libro.precio * tasaDescuento) * this.cantidad);

		double precioConImpuestos = precio * (1 + tasaImpuesto);

		return precioConImpuestos;
	}

	public void imprimeFactura() {
            System.out.println(cantidad + "x " + libro.nombre + " " +          libro.precio + "$");
            System.out.println("Tasa de Descuento: " + tasaDescuento);
            System.out.println("Tasa de Impuesto: " + tasaImpuesto);
            System.out.println("Total: " + total);
	}

        public void guardarArchivo(String nombreArchivo) {
	// Crea un archivo con el nombre dado y escribe la factura.
	}

}
Aquí está nuestra clase de Factura. También contiene algunos campos sobre facturación y 3 métodos:

calculaTotal método que calcula el precio total,
imprimeFactura método que debería imprimir la factura por consola, y
guardaArchivo método responsable de escribir la factura en un archivo.
Debe darse un segundo para pensar en lo que está mal con este diseño de clase antes de leer el siguiente párrafo.

Bien, entonces, ¿qué está pasando aquí? Nuestra clase viola el Principio de Responsabilidad Única de múltiples maneras.

La primera violación es el método imprimeFactura, el cual contiene nuestra lógica de impressión. El PRU establece que nuestra clase solo debería tener una única razón para cambiar, y esa razón debería ser un cambio en el cálculo de la factura para nuestra clase.

Pero en esta arquitectura, si queremos cambiar el formato de impresión, necesitaríamos cambiar la clase. Esta es la razón por la que no deberíamos tener lógica de impresión mezclada con lógica de negocios en la misma clase.

Hay otro método que viola el PRU en nuestra clase: el método guardarArchivo. También es un error extremadamente común mezclar la lógica de persistencia con la lógica de negocios.

No piense solo en términos de escribir en un archivo, podría ser guardarlo en una base de datos, hacer una llamada a la API u otras cosas relacionadas con la persistencia.

Entonces, ¿cómo podemos arreglar esta función de impresión?, puede preguntar.

Podemos crear nuevas clases para nuestra lógica de impresión y persistencia, por lo que ya no necesitaremos modificar la clase de factura para esos fines.

Creamos 2 clases, FacturaImpresion y FacturaPersistencia, y movemos los métodos.

public class FacturaImpresion {
    private Factura factura;

    public FacturaImpresion(Factura factura) {
        this.factura = factura;
    }

    public void imprimir() {
        System.out.println(factura.cantidad + "x " + factura.libro.nombre + " " + factura.libro.precio + " $");
        System.out.println("Tasa de Descuento: " + factura.tasaDescuento);
        System.out.println("Tasa de Impuesto: " + factura.tasaImpuesto);
        System.out.println("Total: " + factura.total + " $");
    }
}
public class FacturaPersistencia {
    Factura factura;

    public FacturaPersistencia(Factura factura) {
        this.factura = factura;
    }

    public void guardarArchivo(String nombreArchivo) {
        // Crea un archivo con el nombre dado y escribe la factura.
    }
}
Ahora nuestra estructura de clases obedece al principio de responsabilidad única y cada clase es responsable de un aspecto de nuestra aplicación. ¡Excelente!

Principio de apertura y cierre
El principio de apertura y cierre exige que las clases deban estar abiertas a la extensión y cerradas a la modificación.

Modificación significa cambiar el código de una clase existente y extensión significa agregar una nueva funcionalidad.

Entonces, lo que este principio quiere decir es: Deberíamos poder agregar nuevas funciones sin tocar el código existente para la clase. Esto se debe a que cada vez que modificamos el código existente, corremos el riesgo de crear errores potenciales. Por lo tanto, debemos evitar tocar el código de producción probado y confiable (en su mayoría) si es posible.

Pero, ¿cómo vamos a agregar una nueva funcionalidad sin tocar la clase?, puede preguntarse. Por lo general, se hace con la ayuda de interfaces y clases abstractas.

Ahora que hemos cubierto los conceptos básicos del principio, apliquémoslo a nuestra aplicación Factura.

Digamos que nuestro jefe vino a nosotros y dijo que quiere que las facturas se guarden en una base de datos para que podamos buscarlas fácilmente. Creemos que está bien, esto es fácil jefe, ¡solo dame un segundo!

Creamos la base de datos, nos conectamos a ella y agregamos un método de guardado a nuestra clase FacturaPersistencia:

public class FacturaPersistencia {
    Factura factura;

    public FacturaPersistencia(Factura factura) {
        this.factura = factura;
    }

    public void guardarArchivo(String nombreArchivo) {
        // Crea un archivo con el nombre dado y escribe la factura.
    }

    public void guardarEnBaseDatos() {
        // Guarda la factura en la base de datos
    }
}
Lamentablemente, nosotros, como desarrolladores perezosos de la librería, no diseñamos las clases para que fueran fácilmente ampliables en el futuro. Entonces, para agregar esta función, hemos modificado la clase FacturaPersistencia.

Si nuestro diseño de clase obedeciera al principio Abierto-Cerrado, no necesitaríamos cambiar esta clase.

Entonces, como el desarrollador perezoso pero inteligente de la librería, vemos el problema de diseño y decidimos refactorizar el código para obedecer el principio.

interface FacturaPersistencia {

    public void guardar(Factura factura);
}
Cambiamos el tipo de FacturaPersistencia a Interface y agregamos un método de guardado. Cada clase de persistencia implementará este método de guardado.

public class BaseDeDatosPersistencia implements FacturaPersistencia {

    @Override
    public void guardar(Factura factura) {
        // Guardar en la base de datos
    }
}
public class ArchivoPersistencia implements FacturaPersistencia {

    @Override
    public void guardar(Factura factura) {
        // Guardar en archivo
    }
}
Así que nuestra estructura de clases ahora se ve así:

SOLID-Tutorial-1-1024x554
Ahora nuestra lógica de persistencia es fácilmente extensible. Si nuestro jefe nos pide que agreguemos otra base de datos y tengamos 2 tipos diferentes de bases de datos como MySQL y MongoDB, podemos hacerlo fácilmente.

Puede pensar que podríamos simplemente crear múltiples clases sin una interfaz y agregar un método de guardado para todas ellas.

Pero supongamos que ampliamos nuestra aplicación y tenemos varias clases de persistencia como FacturaPersistencia, LibroPersistencia y creamos una clase AdministradorPersistencia que administra todas las clases de persistencia:

public class AdministradorPersistencia {
    FacturaPersistencia facturaPersistencia;
    LibroPersistencia libroPersistencia;
    
    public AdministradorPersistencia(FacturaPersistencia facturaPersistencia, LibroPersistencia libroPersistencia) {
        this.facturaPersistencia = facturaPersistencia;
        this.libroPersistencia = libroPersistencia;
    }
}
Ahora podemos pasar cualquier clase que implemente la interfaz FacturaPersistencia a esta clase con la ayuda del polimorfismo. Esta es la flexibilidad que proporcionan las interfaces.
