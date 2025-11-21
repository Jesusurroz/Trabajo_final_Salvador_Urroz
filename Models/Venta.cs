using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autos_Narla_Salvador_Urroz.Models
{
    
    public class Venta
    {
        public int VentaId { get; set; }
       
        public int Id 
        { get => VentaId;
          set => VentaId = value;
        }

        
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal PrecioFinal { get; set; }
        public string MetodoPago { get; set; }
        public decimal DescuentoPorc { get; set; }
        public DateTime FechaVenta { get; set; }

     
        public Venta(int id, int vehiculoId, int clienteId, int empleadoId, decimal precioFinal, string metodoPago, decimal descuentoPorc)
        {
            VentaId = id;
            VehiculoId = vehiculoId;
            ClienteId = clienteId;
            EmpleadoId = empleadoId;
            PrecioFinal = precioFinal;
            MetodoPago = metodoPago;
            DescuentoPorc = descuentoPorc;
            FechaVenta = DateTime.Now;
        }

        public decimal MontoDescuento=>(PrecioFinal*DescuentoPorc)/100;
        public override string ToString()
        {
            return $"Venta #{Id}| Vehiculo:{VehiculoId}|Cliente:{ClienteId}|Total: ${PrecioFinal}";
        }

    }
}
