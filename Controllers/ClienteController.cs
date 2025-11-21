using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autos_Narla_Salvador_Urroz.Models;


namespace Autos_Narla_Salvador_Urroz.Controllers
{
    public class ClienteController
    {
        private List<Cliente> clientes = new List<Cliente>();

        public ClienteController()
        {
            //Ejemplo 
            clientes.Add(new Cliente
            {
                ClienteId = 1,
                Nombre = "williams",
                Apellido = "Urroz",
                Telefono = "78975490",
                Email = "WilliamsU@gmail.com",
                Direccion = "Masaya"
            });

            clientes.Add(new Cliente
            {
                ClienteId = 2,
                Nombre = "winston",
                Apellido = "Urroz",
                Telefono = "78975491",
                Email = "winstonU@gmail.com",
                Direccion = "Granada"
            });

            clientes.Add(new Cliente
            {
                ClienteId = 3,
                Nombre = "Lucía",
                Apellido = "Sarmiento",
                Telefono = "78975491",
                Email = "lucia@gmail.com",
                Direccion = "Managua"
            });
        }

        // Listar todos los clientes
        public List<Cliente> Listar()
        {
            return clientes;
        }

        // Buscar cliente por ID
        public Cliente BuscarPorId(int id)
        {
            return clientes.FirstOrDefault(c => c.ClienteId == id);
        }

        // Agregar nuevo cliente
        public bool Agregar(Cliente nuevo)
        {
            if (clientes.Any(c => c.ClienteId == nuevo.ClienteId))
                return false;

            clientes.Add(nuevo);
            return true;
        }

        // Actualizar teléfono o datos
        public bool Actualizar(int id, string nuevoTelefono, string nuevoEmail = null)
        {
            var cliente = BuscarPorId(id);
            if (cliente == null) return false;

            cliente.Telefono = nuevoTelefono;
            if (!string.IsNullOrEmpty(nuevoEmail))
                cliente.Email = nuevoEmail;

            return true;
        }

        // Eliminar cliente
        public bool Eliminar(int id)
        {
            var cliente = BuscarPorId(id);
            if (cliente == null) return false;

            clientes.Remove(cliente);
            return true;
        }
    }
}
