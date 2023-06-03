using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;


namespace Capa_Entidad
{
    public class Clientes
    {
        public string Codigo { get; set; }
        public string Num_Identificacion { get; set; }
        public string Tipo_Identificacion { get; set; }

        [MaxLength(2, ErrorMessage = "El nombre debe ser de dos caracteres")]
        public string Nombre { get; set; }


       // [MaxLength(2, ErrorMessage = "El apellido debe ser de dos caracteres")]
        public string Primer_Apellido { get; set; }

        //[Required(ErrorMessage = "El Segundo Apellido Es Obligatorio.")]
        public string Segundo_Apellido { get; set; }
     
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = " La Direccion solo debe contener letras.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Perfil_Transaccional Es Obligatorio.")]
        public string Perfil_Transaccional { get; set; }

        [Required(ErrorMessage = "El Nombre del Pais Es Obligatorio.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El Estado_Civil Es Obligatorio.")]
        public string Estado_Civil { get; set; }

        [Required(ErrorMessage = "La Profesion Es Obligatoria.")]
        public string Profesion { get; set; }

        [Required(ErrorMessage = "El Lugar De Trabajo Es Obligatorio.")]
        public string Lugar_Trabajo { get; set; }

        public string Tipo_Cliente { get; set; }

        // Propiedades de navegación
        [JsonIgnore]
        public List<CuentaCorriente> CuentasCorriente { get; set; }
        [JsonIgnore]

        public List<CuentaAhorro> CuentasAhorro { get; set; }
    }
}
