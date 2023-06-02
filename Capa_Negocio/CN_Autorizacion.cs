using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Autorizacion
    {

        private CD_Autorizacion autorizaciones;

        public CN_Autorizacion()
        {
            autorizaciones = new CD_Autorizacion();
        }


        public void CrearAutorizacion(Autorizaciones autorizacion)
        {
            autorizaciones.CrearAutorizacion(autorizacion);
        }




    }
}
