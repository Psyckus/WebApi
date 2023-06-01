
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Clientes
    {
        private string connectionString = Conexion.cn;
      
        

        public void CrearCliente(Clientes cliente)
        {
            // Código para insertar el cliente en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Codigo, Num_Identificacion, Tipo_Identificacion, Nombre, Primer_Apellido, Segundo_Apellido, Direccion, Perfil_Transaccional, Pais, Estado_Civil, Profesion, Lugar_Trabajo, Tipo_Cliente) " +
                               "VALUES (@Codigo, @Num_Identificacion, @Tipo_Identificacion, @Nombre, @Primer_Apellido, @Segundo_Apellido, @Direccion, @Perfil_Transaccional, @Pais, @Estado_Civil, @Profesion, @Lugar_Trabajo, @Tipo_Cliente)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                    command.Parameters.AddWithValue("@Num_Identificacion", cliente.Num_Identificacion);
                    command.Parameters.AddWithValue("@Tipo_Identificacion", cliente.Tipo_Identificacion);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Primer_Apellido", cliente.Primer_Apellido);
                    command.Parameters.AddWithValue("@Segundo_Apellido", cliente.Segundo_Apellido);
                    command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    command.Parameters.AddWithValue("@Perfil_Transaccional", cliente.Perfil_Transaccional);
                    command.Parameters.AddWithValue("@Pais", cliente.Pais);
                    command.Parameters.AddWithValue("@Estado_Civil", cliente.Estado_Civil);
                    command.Parameters.AddWithValue("@Profesion", cliente.Profesion);
                    command.Parameters.AddWithValue("@Lugar_Trabajo", cliente.Lugar_Trabajo);
                    command.Parameters.AddWithValue("@Tipo_Cliente", cliente.Tipo_Cliente);

                    connection.Open();
                    command.ExecuteNonQuery();


                    // Generar usuario y clave aleatorios
                    string usuario = cliente.Num_Identificacion;
                    string clave = GenerarClaveAleatoria();

                    // Insertar usuario y clave en la tabla Credenciales
                    string credencialesQuery = "INSERT INTO Credenciales (Username, Password, Estado) VALUES (@Username, @Password, @Estado)";
                    using (SqlCommand credencialesCommand = new SqlCommand(credencialesQuery, connection))
                    {
                        credencialesCommand.Parameters.AddWithValue("@Username", usuario);
                        credencialesCommand.Parameters.AddWithValue("@Password", clave);
                        credencialesCommand.Parameters.AddWithValue("@Estado", true); // Puedes establecer el estado inicial como activo

                        credencialesCommand.ExecuteNonQuery();
                    }






                }
            }
        }


        private string GenerarUsuarioAleatorio(string numIdentificacion, string nombre)
        {
            string usuario = numIdentificacion.Substring(0, 3) + nombre.Substring(0, 3);
            return usuario;
        }

        private string GenerarClaveAleatoria()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder clave = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                clave.Append(caracteres[random.Next(caracteres.Length)]);
            }

            return clave.ToString();
        }


        public void ActualizarCliente(Clientes cliente)
        {
            // Código para actualizar el cliente en la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Clientes SET Codigo = @Codigo, Nombre = @Nombre, Primer_Apellido = @Primer_Apellido, Segundo_Apellido = @Segundo_Apellido, Direccion = @Direccion, Perfil_Transaccional = @Perfil_Transaccional, Pais = @Pais, Estado_Civil = @Estado_Civil, Profesion = @Profesion, Lugar_Trabajo = @Lugar_Trabajo, Tipo_Cliente = @Tipo_Cliente " +
                               "WHERE Num_Identificacion = @Num_Identificacion";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Primer_Apellido", cliente.Primer_Apellido);
                    command.Parameters.AddWithValue("@Segundo_Apellido", cliente.Segundo_Apellido);
                    command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    command.Parameters.AddWithValue("@Perfil_Transaccional", cliente.Perfil_Transaccional);
                    command.Parameters.AddWithValue("@Pais", cliente.Pais);
                    command.Parameters.AddWithValue("@Estado_Civil", cliente.Estado_Civil);
                    command.Parameters.AddWithValue("@Profesion", cliente.Profesion);
                    command.Parameters.AddWithValue("@Lugar_Trabajo", cliente.Lugar_Trabajo);
                    command.Parameters.AddWithValue("@Tipo_Cliente", cliente.Tipo_Cliente);
                    command.Parameters.AddWithValue("@Num_Identificacion", cliente.Num_Identificacion);  // Usado solo para la cláusula WHERE

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void EliminarCliente(string identificacion)
        {
            // Código para eliminar el cliente de la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Clientes WHERE Num_Identificacion = @Num_Identificacion";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Num_Identificacion", identificacion);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Clientes ObtenerClientePorIdentificacion(string identificacion)
        {
            // Código para obtener el cliente de la base de datos
            // y retornarlo como un objeto Cliente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes WHERE Num_Identificacion = @Num_Identificacion";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Num_Identificacion", identificacion);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Clientes cliente = new Clientes();
                        cliente.Codigo = reader["Codigo"].ToString();
                        cliente.Num_Identificacion = reader["Num_Identificacion"].ToString();
                        cliente.Tipo_Identificacion = Convert.ToInt32(reader["Tipo_Identificacion"]);
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Primer_Apellido = reader["Primer_Apellido"].ToString();
                        cliente.Segundo_Apellido = reader["Segundo_Apellido"].ToString();
                        cliente.Direccion = reader["Direccion"].ToString();
                        cliente.Perfil_Transaccional = Convert.ToInt32(reader["Perfil_Transaccional"]);
                        cliente.Pais = Convert.ToInt32(reader["Pais"]);
                        cliente.Estado_Civil = Convert.ToInt32(reader["Estado_Civil"]);
                        cliente.Profesion = reader["Profesion"].ToString();
                        cliente.Lugar_Trabajo = reader["Lugar_Trabajo"].ToString();
                        cliente.Tipo_Cliente = Convert.ToInt32(reader["Tipo_Cliente"]);

                        return cliente;
                    }
                }
            }

            return null;
        }

        public List<Clientes> ObtenerClientesPorNombre(string nombre)
        {
            // Código para obtener la lista de clientes de la base de datos
            // que coincidan con el nombre y apellidos dados
            // y retornarla como una lista de objetos Cliente
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes WHERE Nombre = @Nombre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
             

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    List<Clientes> clientes = new List<Clientes>();

                    while (reader.Read())
                    {
                        Clientes cliente = new Clientes();
                        cliente.Codigo = reader["Codigo"].ToString();
                        cliente.Num_Identificacion = reader["Num_Identificacion"].ToString();
                        cliente.Tipo_Identificacion = Convert.ToInt32(reader["Tipo_Identificacion"]);
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Primer_Apellido = reader["Primer_Apellido"].ToString();
                        cliente.Segundo_Apellido = reader["Segundo_Apellido"].ToString();
                        cliente.Direccion = reader["Direccion"].ToString();
                        cliente.Perfil_Transaccional = Convert.ToInt32(reader["Perfil_Transaccional"]);
                        cliente.Pais = Convert.ToInt32(reader["Pais"]);
                        cliente.Estado_Civil = Convert.ToInt32(reader["Estado_Civil"]);
                        cliente.Profesion = reader["Profesion"].ToString();
                        cliente.Lugar_Trabajo = reader["Lugar_Trabajo"].ToString();
                        cliente.Tipo_Cliente = Convert.ToInt32(reader["Tipo_Cliente"]);

                        clientes.Add(cliente);
                    }

                    return clientes;
                }
            }
        }
        public List<Clientes> ObtenerClientesPorApellidos(string apellido)
        {
            List<Clientes> clientes = new List<Clientes>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes WHERE Primer_Apellido = @Apellido OR Segundo_Apellido = @Apellido";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Apellido", apellido);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Clientes cliente = new Clientes();
                        cliente.Codigo = reader["Codigo"].ToString();
                        cliente.Num_Identificacion = reader["Num_Identificacion"].ToString();
                        cliente.Tipo_Identificacion = Convert.ToInt32(reader["Tipo_Identificacion"]);
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Primer_Apellido = reader["Primer_Apellido"].ToString();
                        cliente.Segundo_Apellido = reader["Segundo_Apellido"].ToString();
                        cliente.Direccion = reader["Direccion"].ToString();
                        cliente.Perfil_Transaccional = Convert.ToInt32(reader["Perfil_Transaccional"]);
                        cliente.Pais = Convert.ToInt32(reader["Pais"]);
                        cliente.Estado_Civil = Convert.ToInt32(reader["Estado_Civil"]);
                        cliente.Profesion = reader["Profesion"].ToString();
                        cliente.Lugar_Trabajo = reader["Lugar_Trabajo"].ToString();
                        cliente.Tipo_Cliente = Convert.ToInt32(reader["Tipo_Cliente"]);

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

    }



}

