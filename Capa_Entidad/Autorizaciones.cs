using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Autorizaciones
    {

        public string Codigo { get; set; }  

        public string Entidad_Origen { get; set;}

        public string Entidad_Destino { get; set; }

        public string Cuenta_Origen { get; set; }

        public string Cuenta_Destino { get; set; }

        public string Cliente_Autoriza { get; set; }

        public string Cliente_Solicita { get; set; }

        public string Fecha_Inicio { get; set; }

        public string Fecha_Finalizacion { get; set; }

        public string Estado { get; set; }

    }

}
