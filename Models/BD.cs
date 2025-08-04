using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
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

    public static void agregarTarea(Tarea tarea)
    {
        string query = "INSERT INTO Tarea (nombre, id_usuario, fechaCreacion, estaFinalizada, estaBorrada, contenido) VALUES (@pnombre,@pid_usuario, @pfechaCreacion, @pestaFinalizada, @pestaBorrada, @pcontenido)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pnombre = tarea.nombre, pid_usuario=tarea.id_usuario, pfechaCreacion = tarea.fechaCreacion, pestaFinalizada= 0, pestaBorrada=0, pcontenido= tarea.contenido });
        }
    }
        public static void modificarTarea(Tarea tarea, int idUsuario)
        {
            string query = "UPDATE Tarea (contenido) VALUES (@pcontenido) WHERE id_tarea=@ptareaID AND id_usuario=@pidUsuario";
              using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {pcontenido= tarea.contenido, pTareaID=tarea.idTarea, pidUsuario=idUsuario });
        }
        }

}