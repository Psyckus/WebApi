using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Clientes
    {
        private CD_Clientes clientes;
        public CN_Clientes()
        {

            clientes = new CD_Clientes();

        }

        public void CrearCliente(Clientes cliente)
        {
            // Validaciones y reglas de negocio

            // Llamada al método en la capa de datos
            clientes.CrearCliente(cliente);
        }

        public void ActualizarCliente(Clientes cliente)
        {
            // Validaciones y reglas de negocio

            // Llamada al método en la capa de datos
            clientes.ActualizarCliente(cliente);
        }

        public void EliminarCliente(string identificacion)
        {
            // Validaciones y reglas de negocio

            // Llamada al método en la capa de datos
            clientes.EliminarCliente(identificacion);
        }

        public Clientes ObtenerClientePorIdentificacion(string identificacion)
        {
            // Validaciones y reglas de negocio

            // Llamada al método en la capa de datos
            return clientes.ObtenerClientePorIdentificacion(identificacion);
        }

        public List<Clientes> ObtenerClientesPorNombre(string nombre)
        {
            // Validaciones y reglas de negocio

            // Llamada al método en la capa de datos
            return clientes.ObtenerClientesPorNombre(nombre);
        }

        public List<Clientes> ObtenerClientesPorApellidos(string apellido)
        {
            // Validaciones y reglas de negocio

            // Llamada al método en la capa de datos
            return clientes.ObtenerClientesPorApellidos(apellido);
        }

    }
}
