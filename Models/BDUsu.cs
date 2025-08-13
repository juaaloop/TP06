using Microsoft.Data.SqlClient;
using Dapper;
public static class BDUsu
{

    public static string connectionString = @"Server=localhost;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";
    public static bool agregarUsuario(Usuario user)
    {
        int id;
        string query = "EXEC agregarUsuario @pnombreUsuario,@ppassword";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            id = connection.QueryFirstOrDefault<int>(query, new { pnombreUsuario = user.username, ppassword = user.password });

        }
        if(id>0){
            return true;
        }else{
            return false;
        }
        //REVISAR QUE DEVUELVE
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
    public static int obtenerUsuarioId(string nombreUsuario)
    {
        int id;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT id_usuario FROM Usuario WHERE nombreUsuario=@pnombreUsuario";
            id = connection.QueryFirstOrDefault<int>(query, new { pnombreUsuario = nombreUsuario});
        }
        return id;
    }
}