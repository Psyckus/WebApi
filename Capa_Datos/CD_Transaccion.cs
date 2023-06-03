using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Transaccion
    {
        private string connectionString = Conexion.cn;

        private CD_Movimientos datosTransaccion;
 
        public CD_Transaccion()
        {
            datosTransaccion = new CD_Movimientos();
        }

        public void RegistrarTransferencia(Transaccion transferencia)
        {
            // Generar el código de referencia
            string codigoReferencia = GenerarCodigoReferencia();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO transaccion (Codigo, Banco_Origen, Banco_Destino, Cuenta_Origen, Cuenta_Destino, Monto, Cedula_Origen, Cedula_Destino, Moneda, Descripcion, Estado, Motivo, Canal, Tipo_Transaccion_ID) " +
                               "VALUES (@Codigo, @Banco_Origen, @Banco_Destino, @Cuenta_Origen, @Cuenta_Destino, @Monto, @Cedula_Origen, @Cedula_Destino, @Moneda, @Descripcion, @Estado, @Motivo, @Canal, @Tipo_Transaccion_ID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigoReferencia);
                    command.Parameters.AddWithValue("@Banco_Origen", transferencia.BancoOrigen);
                    command.Parameters.AddWithValue("@Banco_Destino", transferencia.BancoDestino);
                    command.Parameters.AddWithValue("@Cuenta_Origen", transferencia.CuentaOrigen);
                    command.Parameters.AddWithValue("@Cuenta_Destino", transferencia.CuentaDestino);
                    command.Parameters.AddWithValue("@Monto", transferencia.Monto);
                    command.Parameters.AddWithValue("@Cedula_Origen", transferencia.CedulaOrigen);
                    command.Parameters.AddWithValue("@Cedula_Destino", transferencia.CedulaDestino);
                    command.Parameters.AddWithValue("@Moneda", transferencia.Moneda);
                    command.Parameters.AddWithValue("@Descripcion", transferencia.Descripcion);
                    command.Parameters.AddWithValue("@Estado", transferencia.Estado);
                    command.Parameters.AddWithValue("@Motivo", transferencia.Motivo);
                    command.Parameters.AddWithValue("@Canal", transferencia.Canal);
                    command.Parameters.AddWithValue("@Tipo_Transaccion_ID", transferencia.Tipo_Transaccion_ID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarSaldoCuentaAhorro(string cuenta, decimal nuevoSaldo)
        {
            // Realizar la actualización del saldo en la tabla Cuentas_Ahorro
            string consulta = "UPDATE Cuentas_Ahorro SET Monto = @NuevoSaldo WHERE Num_Cuenta = @Cuenta";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo);
                    comando.Parameters.AddWithValue("@Cuenta", cuenta);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarSaldoCuentaCorriente(string cuenta, decimal nuevoSaldo)
        {
            // Realizar la actualización del saldo en la tabla Cuenta_Corriente
            string consulta = "UPDATE Cuenta_Corriente SET Monto = @NuevoSaldo WHERE Num_Cuenta = @Cuenta";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo);
                    comando.Parameters.AddWithValue("@Cuenta", cuenta);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }




        public string GenerarCodigoReferencia()
        {
            string entidad = "001";
            string consecutivo = GenerarConsecutivoAleatorio();

            string fechaActual = DateTime.Now.ToString("yyyyMMdd");

            string codigoReferencia = $"{fechaActual}{entidad}-{consecutivo}";

            return codigoReferencia;
        }

        public string GenerarConsecutivoAleatorio()
        {
            // Generar un número de 14 dígitos aleatorio
            Random random = new Random();
            int lowerBound = 10000000;  // Valor mínimo de 8 dígitos
            int upperBound = 99999999;  // Valor máximo de 8 dígitos

            long randomNumber = random.Next(lowerBound, upperBound + 1);

            return randomNumber.ToString("D10");  // Formato de 14 dígitos con ceros a la izquierda si es necesario
        }





        public int ObtenerSaldoCuenta(string cuenta)
        {
            int saldo = 0;

            // Verificar si la cuenta pertenece a la tabla Cuenta_Corriente
            if (datosTransaccion.EsCuentaCorriente(cuenta))
            {
                saldo = ObtenerSaldoCuentaCorriente(cuenta);
            }
            // Verificar si la cuenta pertenece a la tabla Cuentas_Ahorro
            else if (datosTransaccion.EsCuentaAhorro(cuenta))
            {
                saldo = ObtenerSaldoCuentasAhorro(cuenta);
            }
            else
            {
                // La cuenta no existe o no pertenece a ninguna de las tablas
                // Puedes manejar esta situación según tus requisitos
            }

            return saldo;
        }



        
        private int ObtenerSaldoCuentaCorriente(string cuenta)
        {
            int saldo = 0;

            // Realizar la consulta para obtener el saldo de la cuenta en la tabla Cuenta_Corriente
            string consulta = "SELECT Monto FROM Cuenta_Corriente WHERE Num_Cuenta = @Cuenta";

            // Ejecutar la consulta y obtener el resultado
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Cuenta", cuenta);
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null && int.TryParse(resultado.ToString(), out saldo))
                    {
                        // El saldo se ha obtenido exitosamente
                    }
                    else
                    {
                        // No se pudo obtener el saldo, manejar el caso según tus requisitos
                    }
                }
            }

            return saldo;
        }


        private int ObtenerSaldoCuentasAhorro(string cuenta)
        {
            int saldo = 0;

            // Realizar la consulta para obtener el saldo de la cuenta en la tabla Cuenta_Corriente
            string consulta = "SELECT Monto FROM Cuentas_Ahorro WHERE Num_Cuenta = @Cuenta";

            // Ejecutar la consulta y obtener el resultado
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Cuenta", cuenta);
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null && int.TryParse(resultado.ToString(), out saldo))
                    {
                        // El saldo se ha obtenido exitosamente
                    }
                    else
                    {
                        // No se pudo obtener el saldo, manejar el caso según tus requisitos
                    }
                }
            }

            return saldo;

        }



        public TipoTransaccion ObtenerTipoTransaccionPorID(int tipoTransaccionID)
        {
            // Lógica para obtener el tipo de transacción por su ID de la base de datos

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                // Aquí se ejecuta el código de conexión y consulta a la base de datos

                // Supongamos que tienes una consulta SQL para obtener el tipo de transacción por su ID
                string consulta = "SELECT * FROM Tipo_Transacion WHERE ID = @TipoTransaccionID";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@TipoTransaccionID", tipoTransaccionID);

                    TipoTransaccion tipoTransaccion = null;

                    // Abrir la conexión y ejecutar la consulta
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        // Leer los datos del tipo de transacción desde el lector de datos
                        int id = (int)reader["ID"];
                        string nombre = (string)reader["Tipo_Transaccion"];

                        // Crear una instancia de TipoTransaccion con los datos obtenidos
                        tipoTransaccion = new TipoTransaccion(id, nombre);
                    }

                    // Cerrar el lector de datos y la conexión
                    reader.Close();
                    conexion.Close();

                    return tipoTransaccion;
                }
            }

        }
        //Metodo para actualizar el estado de las trasacciones
        public void ActualizarEstado(String codigo,String estado)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE transaccion SET  Estado = @Estado" +
                    "WHERE Codigo = @Codigo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    command.Parameters.AddWithValue("@Estado", estado);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



    }

}