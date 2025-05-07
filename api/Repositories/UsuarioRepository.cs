using api.Interfaces.Repository;
using api.Models;
using Microsoft.Data.SqlClient;

namespace api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM dbo.Usuarios", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Cedula = reader["Cedula"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"]
                        });
                    }
                }
            }
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Cedula = reader["Cedula"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            FechaNacimiento = (DateTime)reader["FechaNacimiento"]
                        };
                    }
                    return null;
                }
            }
        }

        public void Add(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO dbo.Usuarios (Nombre, Apellido, Cedula, Direccion, Telefono, FechaNacimiento) " +
                    "VALUES (@Nombre, @Apellido, @Cedula, @Direccion, @Telefono, @FechaNacimiento)", 
                    connection);

                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                command.Parameters.AddWithValue("@Direccion", usuario.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE dbo.Usuarios SET " +
                    "Nombre = @Nombre, Apellido = @Apellido, Cedula = @Cedula, " +
                    "Direccion = @Direccion, Telefono = @Telefono, FechaNacimiento = @FechaNacimiento " +
                    "WHERE Id = @Id", 
                    connection);

                command.Parameters.AddWithValue("@Id", usuario.Id);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                command.Parameters.AddWithValue("@Direccion", usuario.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", usuario.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM dbo.Usuarios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}