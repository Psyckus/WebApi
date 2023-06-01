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
    public class UsuariosController : ApiController
    {
        private CN_Usuarios cn_usuarios;
        public UsuariosController()
        {
            cn_usuarios = new CN_Usuarios();
        }
        [HttpPost]
        [Route("usuarios/login")]
        public IHttpActionResult Login(Credenciales request)
        {
            try
            {
                // Validar datos de entrada
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest("Los datos de usuario y contraseña son requeridos.");
                }

                // Llamar al método de lógica de negocio para realizar el login
                bool loginResult = cn_usuarios.Login(request.Username, request.Password);

                if (loginResult)
                {
                    return Ok("Login exitoso");
                }
                else
                {
                    return BadRequest("Datos de inicio de sesión incorrectos"); // Agregar BadRequest en caso de datos incorrectos
                }
            }
            catch (Exception ex)
            {
                // Manejar errores no controlados
                return InternalServerError(ex);
            }
        }











    }
}
