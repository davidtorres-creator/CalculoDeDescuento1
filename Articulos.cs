using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoDeDescuento1

{
    // ============================================
    // CLASE BASE - ARTICULO
    // Demuestra: ABSTRACCIÓN Y ENCAPSULAMIENTO
    // ============================================
    public class Articulo
    {
        // Propiedades automáticas (Encapsulamiento)
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        // Constructor
        public Articulo(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        // Método virtual (permite Polimorfismo)
        // Descuento por defecto: 5%
        public virtual decimal CalcularDescuento()
        {
            return Precio * 0.05m;
        }

        // Método para obtener el precio final
        public decimal ObtenerPrecioFinal()
        {
            return Precio - CalcularDescuento();
        }

        // Método para obtener el porcentaje
        public virtual string ObtenerPorcentaje()
        {
            return "5%";
        }
    }

    // ============================================
    // CLASE TECNOLOGIA - HEREDA DE ARTICULO
    // Demuestra: HERENCIA Y POLIMORFISMO
    // ============================================
    public class ArticuloTecnologia : Articulo
    {
        // Constructor que llama al padre
        public ArticuloTecnologia(string nombre, decimal precio)
            : base(nombre, precio)
        {
        }

        // Sobrescribe el método (Polimorfismo)
        // Descuento para tecnología: 10%
        public override decimal CalcularDescuento()
        {
            return Precio * 0.10m;
        }

        public override string ObtenerPorcentaje()
        {
            return "10%";
        }
    }

    // ============================================
    // CLASE ALIMENTO - HEREDA DE ARTICULO
    // Demuestra: HERENCIA Y POLIMORFISMO
    // ============================================
    public class ArticuloAlimento : Articulo
    {
        // Constructor que llama al padre
        public ArticuloAlimento(string nombre, decimal precio)
            : base(nombre, precio)
        {
        }

        // Sobrescribe el método (Polimorfismo)
        // Descuento para alimento: 2%
        public override decimal CalcularDescuento()
        {
            return Precio * 0.02m;
        }

        public override string ObtenerPorcentaje()
        {
            return "2%";
        }
    }
}