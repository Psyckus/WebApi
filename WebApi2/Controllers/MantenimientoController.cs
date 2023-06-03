using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class MantenimientoController : ApiController
    {
        private CN_Clientes cn_clientes;
        public MantenimientoController()
        {
            cn_clientes = new CN_Clientes();
        }

        [HttpPost]
        public IHttpActionResult CrearCliente(Clientes cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cn_clientes.CrearCliente(cliente);
            return CreatedAtRoute("DefaultApi",new {id = cliente.Codigo},cliente);
        }

        [HttpPut]
        public IHttpActionResult ActualizarCliente(Clientes cliente)
        {
            cn_clientes.ActualizarCliente(cliente);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult EliminarCliente(string identificacion)
        {
            cn_clientes.EliminarCliente(identificacion);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult ObtenerClientePorIdentificacion(string identificacion)
        {
            var cliente = cn_clientes.ObtenerClientePorIdentificacion(identificacion);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet]
        [Route("api/Mantenimiento/ObtenerClientesPorNombre")]
        public IHttpActionResult ObtenerClientesPorNombre(string nombre)
        {
            var clientes = cn_clientes.ObtenerClientesPorNombre(nombre);
            return Ok(clientes);
        }
        [HttpGet]
        [Route("api/Mantenimiento/ObtenerClientesPorApellido")]
        public IHttpActionResult ObtenerClientesPorApellido(string apellido)
        {
            var clientes = cn_clientes.ObtenerClientesPorApellidos(apellido);
            return Ok(clientes);
        }
    }
}
