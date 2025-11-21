using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autos_Narla_Salvador_Urroz.Controllers;


namespace Autos_Narla_Salvador_Urroz.Views
{
    public partial class GestionVentas : Form
    {
        private VentaController ventaCtrl;
        private VehiculoController vehCtrl;
        private Button btnSimularVenta;

        public GestionVentas(VentaController vCtrl, VehiculoController vehController)
        {
            ventaCtrl = vCtrl;
            vehCtrl = vehController;
            this.Text = "Gestión de Ventas (Simulado)";
            this.Width = 420;
            this.Height = 200;

            btnSimularVenta = new Button { Text = "Simular Venta", Dock = DockStyle.Fill };
            btnSimularVenta.Click += BtnSimularVenta_Click;
            Controls.Add(btnSimularVenta);
        }

        private void BtnSimularVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Simulación: usa primer vehículo disponible
                var v = vehCtrl.ListarVehiculos().Find(x => x.Stock > 0);
                if (v == null) throw new Exception("No hay vehículos con stock disponible.");

                // Reemplazamos v.Id por v.VehiculoId
                var venta = ventaCtrl.RegistrarVenta(
                    v.VehiculoId,  // ID del vehículo
                    1,             // ID del cliente simulado
                    1,             // Cantidad
                    v.PrecioVenta, // Precio
                    "Efectivo",    // Forma de pago
                    0              // Descuento
                );

                // Reducir stock del vehículo
                vehCtrl.ReducirStock(v.VehiculoId);

                MessageBox.Show($"Venta creada (ID {venta.VentaId}). Stock del vehículo reducido.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
