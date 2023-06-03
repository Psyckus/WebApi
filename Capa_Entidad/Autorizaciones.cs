using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Capa_Entidad
{
    public class Autorizaciones
    {

        public string Codigo { get; set; }

        [Required(ErrorMessage = "La Entidad Origen es obligatorio.")]
        public string Entidad_Origen { get; set;}

        [Required(ErrorMessage = "La Entidad Destino es obligatorio.")]
        public string Entidad_Destino { get; set; }

        [Required(ErrorMessage = "La cuenta de Origen es obligatoria.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "La cuenta de Origen solo debe contener números.")]
        public string Cuenta_Origen { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "La cuenta de Destino solo debe contener números.")]
        public string Cuenta_Destino { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = " El Cliente Autoriza solo debe contener letras.")]
        public string Cliente_Autoriza { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = " El Cliente Solicita solo debe contener letras.")]
        public string Cliente_Solicita { get; set; }


        [DataType(DataType.Date, ErrorMessage = "El campo Fecha_Inicio debe ser una fecha válida.")]
        public string Fecha_Inicio { get; set; }

        [DataType(DataType.Date, ErrorMessage = "El campo Fecha_Finalizacion debe ser una fecha válida.")]
        public string Fecha_Finalizacion { get; set; }

        public string Estado { get; set; }

    }

}
