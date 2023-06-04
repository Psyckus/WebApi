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
    public class MovimientosController : ApiController
    {

        private CN_RegistrarMovimiento cn_movimientos;

        public MovimientosController()
        {
            cn_movimientos = new CN_RegistrarMovimiento();
        }


        [HttpPost]
        [Route("api/movimientos/registrar")]
        public IHttpActionResult RegistrarMovimiento(Movimiento movimiento)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    // Si la validación falla, se retorna un error de BadRequest con los mensajes de validación
                    return BadRequest(ModelState);
                }
                cn_movimientos.RegistrarMovimientos(movimiento);
                return Ok("Movimiento registrado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error y retornar una respuesta con el código de error apropiado
                return BadRequest("Error al registrar el movimiento: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("api/movimientos/registrarcorriente")]
        public IHttpActionResult RegistrarMovimientoCorriente(MovimientoCorriente movimientoCorriente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Si la validación falla, se retorna un error de BadRequest con los mensajes de validación
                    return BadRequest(ModelState);
                }
                cn_movimientos.RegistrarMovimientoCorriente(movimientoCorriente);
                return Ok("Movimiento registrado correctamente.");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error y retornar una respuesta con el código de error apropiado
                return BadRequest("Error al registrar el movimiento: " + ex.Message);
            }
        }
          
        [HttpGet]
        [Route("api/movimientos/obtener/{numCuenta}")]
        public IHttpActionResult ObtenerMovimientosPorCuenta(string numCuenta)
        {
            try
            {
                List<Movimiento> movimientos = cn_movimientos.ObtenerMovimientosPorCuenta(numCuenta);
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener los movimientos por cuenta: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/movimientos/obtenercorrientes/{numCuenta}")]
        public IHttpActionResult ObtenerMovimientosCorrientesPorCuenta(string numCuenta)
        {
            try
            {
                List<MovimientoCorriente> movimientosCorrientes = cn_movimientos.ObtenerMovimientosCorrientesPorCuenta(numCuenta);
                return Ok(movimientosCorrientes);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al obtener los movimientos corrientes por cuenta: " + ex.Message);
            }
        }

    }
}
