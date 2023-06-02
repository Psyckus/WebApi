using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Capa_Entidad
{
    public class Credenciales
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }


    }
}
