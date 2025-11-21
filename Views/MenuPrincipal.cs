using System;
using System.Windows.Forms;
using Autos_Narla_Salvador_Urroz.Controllers;

namespace Autos_Narla_Salvador_Urroz.Views
{
    public partial class MenuPrincipal : Form
    {
        VehiculoController vehiculoCtrl = new VehiculoController();
        VentaController ventaCtrl = new VentaController();

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            dataGridView1.DataSource = vehiculoCtrl.ListarVehiculos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Ingrese un código para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = vehiculoCtrl.BuscarPorCodigo(codigo);
            if (resultado != null)
                dataGridView1.DataSource = new[] { resultado };
            else
                MessageBox.Show("Vehículo no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListarVehiculos_Click(object sender, EventArgs e)
        {
            CargarVehiculos();
            MessageBox.Show("Vehículos listados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal min = 10000;
                decimal max = 30000;
                dataGridView1.DataSource = vehiculoCtrl.FiltrarPorPrecio(min, max);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Ejemplo de datos que podés luego conectar a tus formularios
                int vehiculoId = 1;       // ID del vehículo seleccionado
                int empleadoId = 1;       // ID del empleado (puede ser fijo por ahora)
                decimal precio = 15000m;  // Precio del vehículo
                string metodoPago = "Efectivo";
                decimal descuento = 0;    // Si aplica un descuento, por ejemplo 5m para 5%

                // Llamada correcta (usa la versión simplificada del método)
                var nuevaVenta = ventaCtrl.RegistrarVenta(vehiculoId, empleadoId, precio, metodoPago, descuento);

                MessageBox.Show($"Venta registrada correctamente.\nID: {nuevaVenta.Id}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
