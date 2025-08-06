using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
{

    public static string connectionString = @"Server=localhost\SQLEXPRESS01;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";

    public static void agregarTarea(Tarea tarea)
    {
        string query = "INSERT INTO Tarea (nombre, id_usuarioog, fechaCreacion, estaFinalizada, estaBorrada, contenido) VALUES (@pnombre,@pid_usuario, @pfechaCreacion, @pestaFinalizada, @pestaBorrada, @pcontenido)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pnombre = tarea.nombre, pid_usuario=tarea.id_usuario, pfechaCreacion = DateTime.Today, pestaFinalizada= 0, pestaBorrada=0, pcontenido= tarea.contenido });
        }
    }
    public static void modificarTarea(Tarea tarea, int idUsuario)
    {
        string query = "UPDATE Tarea (contenido) VALUES (@pcontenido) WHERE id_tarea=@ptareaID AND id_usuarioog=@pidUsuario";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {pcontenido= tarea.contenido, pTareaID=tarea.idTarea, pidUsuario=idUsuario });
        }
    }
    public static List<Tarea> levantarTarea(Usuario usuario){
        
        List<Tarea> tarea=new List<Tarea>(); 
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query="SELECT * FROM tarea WHERE id_tarea IN (SELECT id_Tarea FROM tareaxUsuario WHERE id_usuario=@pidUsuario) AND estaborrada=0"
            tarea=connection.Query<Tarea>(query).ToList();
        }
    }
    public static void eliminarTarea(int id_Tarea){
        string query="UPDATE Tarea (estaBorrada) VALUES (1) WHERE id_tarea=@ptareaID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea});
        }
    }
      public static void terminarTarea(int id_Tarea){
        string query="UPDATE Tarea (estaFinalizada) VALUES (1) WHERE id_tarea=@ptareaID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea});
        }
    }

    public static void compartirTarea(Usuario usuarioNuevo, Usuario UsuarioOg, int id_Tarea)
    {
        string query = "INSERT INTO tareaxUsuario (id_tarea,id_Usuario) VALUES (@pidTarea,@pid_usuario) WHERE (SELECT id_usuario FROM Tarea WHERE id_tarea=@pidTarea)IN@pid_Og";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {pidTarea=id_Tarea,pid_usuario=usuarioNuevo.idUsuario,pid_Og=UsuarioOg.idUsuario});
        }
    }

    public static void agregarALista(int id_Tarea,Lista lista){
        string query="UPDATE Tarea (id_lista) VALUES (@pidLista) WHERE id_tarea=@ptareaID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea,pidLista=lista.idLista});
        }
    }
}
