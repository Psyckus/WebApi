using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Usuarios
    {

        private CD_Usuarios Usuarios;
        public CN_Usuarios()
        {

            Usuarios = new CD_Usuarios();

        }

        public bool Login(string username, string password)
        {
            // Validar el usuario y la contraseña en la capa de acceso a datos
            bool loginResult = Usuarios.ValidarCredenciales(username, password);

            return loginResult;
        }



    }
}
