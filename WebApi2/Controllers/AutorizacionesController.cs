using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Capa_Entidad;
using Capa_Negocio;

namespace WebApi2.Controllers
{
    public class AutorizacionesController : ApiController
    {

        private CN_Autorizacion cn_autorizacion;


        public AutorizacionesController()
        {
            cn_autorizacion = new CN_Autorizacion();
        }


        //Registrar una autorizacion

        [HttpPost]
        public IHttpActionResult CrearAutorizacion(Autorizaciones autorizacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cn_autorizacion.CrearAutorizacion(autorizacion);
            return CreatedAtRoute("DefaultApi", new { id = autorizacion.Codigo }, autorizacion);
        }

        //Actualizar el estado de las actualizaciones
        [HttpPut]
        public IHttpActionResult ActualizarAutorizacion(Autorizaciones autorizacion)
        {
            cn_autorizacion.ActualizarAutorizacion(autorizacion);
            return Ok();
        }




    }
}