using Microsoft.Data.SqlClient;
using Dapper;
public static class BDUsu
{

    public static string connectionString = @"Server=localhost\SQLEXPRESS01;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";
    public static void agregarUsuario(Usuario user)
    {
        string query = "INSERT INTO Usuario (nombreUsuario, password) VALUES (@pnombreUsuario, @ppassword)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pnombreUsuario = user.username, ppassword = user.password });
        }
    }
    public static Usuario obtenerUsuario(string nombreUsuario, string password)
    {
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE nombreUsuario=@pnombreUsuario AND password=@ppassword";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { pnombreUsuario = nombreUsuario, ppassword = password });
        }
        return usuario;
    }
    public static bool yaExiste(string NombreUsuario)
    {
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            string query = "SELECT * FROM Usuario WHERE nombreUsuario=@pnombreUsuario";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new { pnombreUsuario = NombreUsuario });

        }
        return usuario != null;
    }
}
