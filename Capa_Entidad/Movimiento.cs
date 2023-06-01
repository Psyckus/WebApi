using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Movimiento
    {
        public int ID { get; set; }
        public string Cuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public int Monto { get; set; }
        public string TipoTransaccion { get; set; }
        public int Identificador { get; set; }
        public string Descripcion { get; set; }
        public string Canal { get; set; }

        // Propiedades de navegación
        public CuentaAhorro CuentaAhorro { get; set; }
    }
}
