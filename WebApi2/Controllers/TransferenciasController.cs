
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
   
 
    public class TransferenciasController : ApiController
    {
        private CN_Transaccion gestorTransacciones;

        public TransferenciasController()
        {
            gestorTransacciones = new CN_Transaccion();
        }

        [Route("api/transferencias")]

        [HttpPost]
        public IHttpActionResult RegistrarTransferencia(Transaccion transaccion)
        {
            try
            {
                // Validar los datos de la transacción
                // ...

                // Registrar la transferencia interbancaria
                gestorTransacciones.RegistrarTransferencia(transaccion);

                return Ok("Transferencia registrada exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Actualizar el estado de las transferencia interbancarias







    }
}
