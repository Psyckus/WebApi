using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_Autorizacion
    {
        private string connectionString = Conexion.cn;


        public void CrearAutorizacion(Autorizaciones autorizacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Autorizacion(Codigo,Entidad_Origen,Entidad_Destino,Cuenta_Origen,Cuenta_Destino" +
                    ",Cliente_Autoriza, Cliente_Solicita,Fecha_Inicio,Fecha_Finalizacion,Estado) VALUES(@Codigo,@Entidad_Origen,@Entidad_Destino,@Cuenta_Origen,@Cuenta_Destino" +
                    ",@Cliente_Autoriza,@Cliente_Solicita,@Fecha_Inicio,@Fecha_Finalizacion,@Estado)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", autorizacion.Codigo);
                    command.Parameters.AddWithValue("@Entidad_Origen", autorizacion.Entidad_Origen);
                    command.Parameters.AddWithValue("@Entidad_Destino", autorizacion.Entidad_Destino);
                    command.Parameters.AddWithValue("@Cuenta_Origen", autorizacion.Cuenta_Origen);
                    command.Parameters.AddWithValue("@Cuenta_Destino", autorizacion.Cuenta_Destino);
                    command.Parameters.AddWithValue("@Cliente_Autoriza", autorizacion.Cliente_Autoriza);
                    command.Parameters.AddWithValue("@Cliente_Solicita", autorizacion.Cliente_Solicita);
                    command.Parameters.AddWithValue("@Fecha_Inicio", autorizacion.Fecha_Inicio);
                    command.Parameters.AddWithValue("@Fecha_Finalizacion", autorizacion.Fecha_Finalizacion);
                    command.Parameters.AddWithValue("@Estado", autorizacion.Estado);
            

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }



        }


        public void ActualizarAutorizacion(Autorizaciones autorizacion)
        {
            // Código para actualizar el cliente en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Autorizacion SET  Entidad_Origen = @Entidad_Origen,Entidad_Destino = @Entidad_Destino, Cuenta_Origen = @Cuenta_Origen,Cuenta_Destino = @Cuenta_Destino,Cliente_Autoriza = @Cliente_Autoriza,Cliente_Solicita = @Cliente_Solicita,Fecha_Inicio = @Fecha_Inicio,Fecha_Finalizacion = @Fecha_Finalizacion,Estado = @Estado " +
                    "WHERE Codigo = @Codigo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", autorizacion.Codigo);
                    command.Parameters.AddWithValue("@Entidad_Origen", autorizacion.Entidad_Origen);
                    command.Parameters.AddWithValue("@Entidad_Destino", autorizacion.Entidad_Destino);
                    command.Parameters.AddWithValue("@Cuenta_Origen", autorizacion.Cuenta_Origen);
                    command.Parameters.AddWithValue("@Cuenta_Destino", autorizacion.Cuenta_Destino);
                    command.Parameters.AddWithValue("@Cliente_Autoriza", autorizacion.Cliente_Autoriza);
                    command.Parameters.AddWithValue("@Cliente_Solicita", autorizacion.Cliente_Solicita);
                    command.Parameters.AddWithValue("@Fecha_Inicio", autorizacion.Fecha_Inicio);
                    command.Parameters.AddWithValue("@Fecha_Finalizacion", autorizacion.Fecha_Finalizacion);
                    command.Parameters.AddWithValue("@Estado", autorizacion.Estado);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
            }
        }




