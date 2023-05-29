using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Clientes
    {
        public string Codigo { get; set; }
        public string Num_Identificacion { get; set; }
        public int Tipo_Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Direccion { get; set; }
        public int Perfil_Transaccional { get; set; }
        public int Pais { get; set; }
        public int Estado_Civil { get; set; }
        public string Profesion { get; set; }
        public string Lugar_Trabajo { get; set; }
        public int Tipo_Cliente { get; set; }
    }
}
