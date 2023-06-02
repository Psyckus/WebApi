using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capa_Entidad
{
    public class Clientes
    {
        public string Codigo { get; set; }
        public string Num_Identificacion { get; set; }
        public int Tipo_Identificacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Primer apellido es requerido")]
        public string Primer_Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Segundo apellido es requerido")]
        public string Segundo_Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Direccion es requerida")]
        public string Direccion { get; set; }


        public int Perfil_Transaccional { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Pais Es Requerido")]
        public int Pais { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Estado_Civil Es Requerido")]
        public int Estado_Civil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Profesion Es Requerida")]
        public string Profesion { get; set; }

        public string Lugar_Trabajo { get; set; }

        public int Tipo_Cliente { get; set; }

        // Propiedades de navegación
        [JsonIgnore]
        public List<CuentaCorriente> CuentasCorriente { get; set; }
        [JsonIgnore]

        public List<CuentaAhorro> CuentasAhorro { get; set; }
    }
}
