using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CN_Transaccion
    {

        private CD_Transaccion datosTransaccion;
        private CD_Movimientos MoviTransaccion;
        private CN_Recursos recursos;

        public CN_Transaccion()
        {
            datosTransaccion = new CD_Transaccion();
            MoviTransaccion = new CD_Movimientos();
            recursos = new CN_Recursos();
        }

   

  



        public void RegistrarTransferencia(Transaccion transferencia)
        {
            // Validar datos de la transferencia
         
   
                if (transferencia.BancoDestino == "001" && transferencia.BancoOrigen != "001")
                {
           
                // Verificar saldo de la cuenta de origen y estado activo

                TipoTransaccion tipoTransaccion= datosTransaccion.ObtenerTipoTransaccionPorID(transferencia.Tipo_Transaccion_ID);
                if (tipoTransaccion != null && (tipoTransaccion.Tipo_Transaccion == "Solicitud de dinero en tiempo real"))
                {
                    if (!VerificarSaldoSuficiente(transferencia.CuentaOrigen, transferencia.Monto))
                    {
                        throw new Exception("No hay suficientes fondos en la cuenta de origen.");
                    }
                    if (!recursos.VerificarEstadoActivo(transferencia.CuentaOrigen))
                    {
                        throw new Exception("La cuenta de origen no está activa.");
                    }

                }
                // Guardar la transacción en la base de datos
                datosTransaccion.RegistrarTransferencia(transferencia);
                }
                else if(transferencia.BancoDestino != "001" && transferencia.BancoOrigen == "001" ) 
                {
             
          
                TipoTransaccion tipoTransaccion = datosTransaccion.ObtenerTipoTransaccionPorID(transferencia.Tipo_Transaccion_ID);
                if (tipoTransaccion.Tipo_Transaccion == "Envío de dinero en tiempo real")
                {
                    if (!VerificarSaldoSuficiente(transferencia.CuentaOrigen, transferencia.Monto))
                    {
                        throw new Exception("No hay suficientes fondos en la cuenta de origen.");
                    }
                    if (!recursos.VerificarEstadoActivo(transferencia.CuentaOrigen))
                    {
                        throw new Exception("La cuenta de origen no está activa.");

                    }

                }

                // Guardar la transacción en el core y en el sistema de transferencias
       

                // Guardar la transacción en la base de datos
                datosTransaccion.RegistrarTransferencia(transferencia);
            }else if(transferencia.BancoOrigen == "001" && transferencia.BancoDestino == "001" || transferencia.BancoOrigen != "001" && transferencia.BancoDestino != "001")
            {
                throw new Exception("Error No se puede procesar la solicitud ..Porfavor revisar el origen o el destino.");
            }

            datosTransaccion.RegistrarTransferencia(transferencia);
        }



        private bool VerificarSaldoSuficiente(string cuentaOrigen, int monto)
        {
            //Realizar la lógica de verificación del saldo en la cuenta de origen
            // Obtener el saldo actual de la cuenta

            bool cuentaAhorro= MoviTransaccion.EsCuentaAhorro(cuentaOrigen);

            if (cuentaAhorro)
            {
                // Realizar la lógica para cuentas de ahorro
                // Obtener el saldo actual de la cuenta
                decimal saldoActual = datosTransaccion.ObtenerSaldoCuenta(cuentaOrigen);

                // Verificar si el saldo es suficiente para realizar la transferencia
                if (saldoActual >= monto)
                {
                    // Restar el monto de la cuenta de ahorro
                    datosTransaccion.ActualizarSaldoCuentaAhorro(cuentaOrigen, saldoActual-monto);
                    return true; // El saldo es suficiente
                }
                else
                {
                    return false; // El saldo es insuficiente
                }
            }
            else
            {
                // Realizar la lógica para cuentas corrientes
                // Agrega aquí la lógica específica para cuentas corrientes
                // ...
                decimal saldoActual = datosTransaccion.ObtenerSaldoCuenta(cuentaOrigen);
                // Retornar true o false según corresponda
                if (saldoActual >= monto)
                {
                    datosTransaccion.ActualizarSaldoCuentaCorriente(cuentaOrigen, saldoActual - monto);
                    return true; // El saldo es suficiente
                }
                else
                {
                    return false; // El saldo es insuficiente
                }
            }
        }

      





















































    }
}
