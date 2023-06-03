using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Transaccion
    {
        public string codigo { get; set; }
  
        public string BancoOrigen { get; set; }
        public string BancoDestino { get; set; }
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public int Monto { get; set; }
        public string CedulaOrigen { get; set; }
        public string CedulaDestino { get; set; }
        public int Moneda { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string Motivo { get; set; }
        public int Canal { get; set; }
        public int Tipo_Transaccion_ID { get; set; }



    }
}
