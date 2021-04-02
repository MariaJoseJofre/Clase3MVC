using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Clase3MVC.Models
{
    //Esta seria para hacer todo sobre la conexion a la base

    public class RepositorioPersona
    {
        private readonly string connectionString;
        public RepositorioPersona()
        {
            connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=inmobiliariaJofre;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public List<Persona> Obtener()
        {
            var res = new List<Persona>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT {nameof(Persona.Id)}, Nombre, Email FROM Personas";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var e = new Persona
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email = reader.GetString(2)
                        };
                        res.Add(e);
                    }
                    connection.Close();
                }
            }

            return res;
        }

        public int Alta(Persona e)
        {
            var res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Personas ({nameof(Persona.Nombre)}, {nameof(Persona.Email)})" +
                    "VALUES (@nombre, @email);" +
                    "SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nombre", e.Nombre);
                    command.Parameters.AddWithValue("@email", e.Email);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    e.Id = res;
                    connection.Close();
                }
            }
            return res;
        }


    }
}
