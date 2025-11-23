using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoDeDescuento1

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Evento Load - Se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cargar tipos de productos en el ComboBox
            cmbTipo.Items.Add("Tecnología");
            cmbTipo.Items.Add("Alimento");
            cmbTipo.Items.Add("General");
            cmbTipo.SelectedIndex = 0;

            // Inicializar label resultado vacío
            lblResultado.Text = "";
        }

        // Evento Click del botón Calcular
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN 1: Nombre no vacío
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre del producto",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // VALIDACIÓN 2: Precio no vacío
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Por favor ingrese el precio del producto",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return;
            }

            // VALIDACIÓN 3: Precio numérico válido
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido",
                    "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                txtPrecio.SelectAll();
                return;
            }

            // VALIDACIÓN 4: Precio mayor que cero
            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero",
                    "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                txtPrecio.SelectAll();
                return;
            }

            // Obtener datos del formulario
            string nombre = txtNombre.Text;
            string tipo = cmbTipo.SelectedItem.ToString();

            // Crear el artículo según el tipo (POLIMORFISMO)
            Articulo articulo;

            if (tipo == "Tecnología")
            {
                articulo = new ArticuloTecnologia(nombre, precio);
            }
            else if (tipo == "Alimento")
            {
                articulo = new ArticuloAlimento(nombre, precio);
            }
            else
            {
                articulo = new Articulo(nombre, precio);
            }

            // Calcular valores
            decimal descuento = articulo.CalcularDescuento();
            decimal precioFinal = articulo.ObtenerPrecioFinal();
            string porcentaje = articulo.ObtenerPorcentaje();

            // Construir mensaje de resultado
            string mensaje = "===== CÁLCULO DE DESCUENTO =====\n\n";
            mensaje += "Producto: " + nombre + "\n";
            mensaje += "Tipo: " + tipo + "\n";
            mensaje += "Precio Original: " + precio.ToString("C") + "\n";
            mensaje += "Descuento (" + porcentaje + "): " + descuento.ToString("C") + "\n";
            mensaje += "-----------------------------------\n";
            mensaje += "PRECIO FINAL: " + precioFinal.ToString("C");

            // Mostrar en Label
            lblResultado.Text = mensaje;

            // Mostrar en MessageBox
            MessageBox.Show(mensaje, "Descuento Calculado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento Click del botón Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            cmbTipo.SelectedIndex = 0;
            lblResultado.Text = "";
            txtNombre.Focus();
        }

        // Validación para que solo se ingresen números en el precio
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, backspace y punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && txtPrecio.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // Eventos opcionales (pueden estar vacíos)
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}