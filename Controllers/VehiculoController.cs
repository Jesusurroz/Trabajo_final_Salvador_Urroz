using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autos_Narla_Salvador_Urroz.Models;

namespace Autos_Narla_Salvador_Urroz.Controllers
{
    public class VehiculoController
    {

         AutoNarlaContext context = new ();
        private List<Vehiculo> vehiculos = new List<Vehiculo>();

        public VehiculoController()
        {
            vehiculos.Add(new Vehiculo
            {
  
                Codigo = "VH001",
                VehiculoId = 1,
                MarcaId = 1,
                Modelo = "Corolla",
                AñoProduccion = 2018,
                TipoVehiculoId = 1,
                PrecioVenta = 14500,
                Cilindraje = 1.8m,
                Estado = "Disponible",
                Stock = 2,
                Categoria = "Sedan"
            });

            vehiculos.Add(new Vehiculo
            {
                
                Codigo = "VH002",
                VehiculoId = 2,
                MarcaId = 2,
                Modelo = "Civic",
                AñoProduccion = 2020,
                TipoVehiculoId = 1,
                PrecioVenta = 17000,
                Cilindraje = 2.0m,
                Estado = "Disponible",
                Stock = 5,
                Categoria = "Hatchback"
            });

            vehiculos.Add(new Vehiculo
            {
        
                Codigo = "VH003",
                VehiculoId = 3,
                MarcaId = 3,
                Modelo = "F-150",
                AñoProduccion = 2017,
                TipoVehiculoId = 2,
                PrecioVenta = 28000,
                Cilindraje = 3.5m,
                Estado = "Disponible",
                Stock = 3,
                Categoria = "Pickup"
            });
        }

        public List<Vehiculo> ListarVehiculos() => vehiculos;

        public Vehiculo BuscarPorCodigo(string codigo) =>
            vehiculos.FirstOrDefault(v => v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

        public void AgregarVehiculo(Vehiculo v)
        {
            int totalMismoModelo = vehiculos
                .Where(x => x.Modelo.Equals(v.Modelo, StringComparison.OrdinalIgnoreCase))
                .Sum(x => x.Stock);

            if (totalMismoModelo + v.Stock > 4)
                throw new InvalidOperationException("No se pueden tener más de 4 unidades del mismo modelo en el inventario.");

            v.VehiculoId = vehiculos.Any() ? vehiculos.Max(x => x.VehiculoId) + 1 : 1;
            context.Vehiculos.Add(v);
            context.SaveChanges();
        }

        public void ActualizarPrecio(int id, decimal nuevoPrecio)
        {
            var veh =context.Vehiculos.FirstOrDefault(x => x.VehiculoId == id);
            if (veh == null) throw new KeyNotFoundException("Vehículo no encontrado.");
            veh.PrecioVenta = nuevoPrecio;
            context.SaveChanges();
        }

        public List<Vehiculo> FiltrarPorModeloYAño(string modelo, int? año)
        {
            return context.Vehiculos.Where(v =>
                (string.IsNullOrEmpty(modelo) || v.Modelo.IndexOf(modelo, StringComparison.OrdinalIgnoreCase) >= 0)
                && (!año.HasValue || v.AñoProduccion == año.Value)
            ).ToList();

        }

        public List<Vehiculo> FiltrarPorRangoPrecio(decimal min, decimal max, string categoria = null)
        {
            return context.Vehiculos.Where(v =>
                v.PrecioVenta >= min &&
                v.PrecioVenta <= max &&
                (string.IsNullOrEmpty(categoria) || v.Categoria == categoria)
            ).ToList();
        }

        public Vehiculo ObtenerMasAntiguo()
        {
            return context.Vehiculos.OrderBy(v => v.AñoProduccion).FirstOrDefault();
        }

        public Vehiculo ObtenerMayorCilindraje()
        {
            return context.Vehiculos.OrderByDescending(v => v.Cilindraje).FirstOrDefault();
        }

        public Vehiculo ObtenerPrecioMasBajo()
        {
            return context.Vehiculos.OrderBy(v => v.PrecioVenta).FirstOrDefault();
        }

        public void ReducirStock(int vehiculoId)
        {
            var veh =context.Vehiculos.FirstOrDefault(x => x.VehiculoId == vehiculoId);
            if (veh == null) throw new KeyNotFoundException("Vehículo no encontrado.");
            if (veh.Stock <= 0) throw new InvalidOperationException("No hay stock disponible para este vehículo.");

            veh.Stock -= 1;
            if (veh.Stock == 0)
                veh.Codigo += "_VENDIDO";
            context.SaveChanges();
        }

        public List<Vehiculo> FiltrarPorPrecio(decimal precioMin, decimal precioMax)
        {
            return context.Vehiculos
                .Where(v => v.PrecioVenta >= precioMin && v.PrecioVenta <= precioMax)
                .ToList();
        }

        public void AplicarDescuento(string codigo, decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 10)
                throw new InvalidOperationException("Descuento permitido: 0% - 10%.");

            var veh = BuscarPorCodigo(codigo);
            if (veh == null) throw new KeyNotFoundException("Vehículo no encontrado.");

            veh.PrecioVenta = Math.Round(veh.PrecioVenta * (1 - porcentaje / 100m), 2);
            context.SaveChanges();
        }
    }
}
