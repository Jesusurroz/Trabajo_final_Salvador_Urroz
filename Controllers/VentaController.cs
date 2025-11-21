using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autos_Narla_Salvador_Urroz.Models;


namespace Autos_Narla_Salvador_Urroz.Controllers
{
    public class VentaController
    {
       
        private List<Venta> ventas = new List<Venta>();
        private int nextId = 1;
        private VehiculoController vehCtrl;

        public VentaController(VehiculoController vehController = null)
        {
            
            vehCtrl = vehController ?? new VehiculoController();
        }

        
        public List<Venta> Listar() => ventas;


        public Venta RegistrarVenta(int vehiculoId, int clienteId, int empleadoId, decimal precioFinal, string metodoPago, decimal descuentoPorc = 0m)
        {
            if (descuentoPorc < 0 || descuentoPorc > 10)
                throw new InvalidOperationException("El descuento máximo permitido es del 10%.");

            
            vehCtrl.ReducirStock(vehiculoId);

           
            var venta = new Venta(nextId++, vehiculoId, clienteId, empleadoId, precioFinal, metodoPago, descuentoPorc);
            ventas.Add(venta);
            return venta;
        }

        
        public Venta RegistrarVenta(int vehiculoId, int empleadoId, decimal precio, string formaPago, decimal descuento)
        {
            int clienteId = 1; 
            return RegistrarVenta(vehiculoId, clienteId, empleadoId, precio, formaPago, descuento);
        }

        
        public decimal TotalIngresos() => ventas.Sum(v => v.PrecioFinal);

        
        public List<Venta> FiltrarPorFecha(DateTime inicio, DateTime fin)
        {
            return ventas
                .Where(v => v.FechaVenta.Date >= inicio.Date && v.FechaVenta.Date <= fin.Date)
                .ToList();
        }
    }
}
