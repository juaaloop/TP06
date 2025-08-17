using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
{

    public static string connectionString = @"Server=localhost;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";

    public static void agregarTarea(Tarea tarea)
    {
        int id;
        string query = "EXEC agregarTarea @pnombre, @pid_usuario,@pcontenido";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            id = connection.QueryFirstOrDefault<int>(query, new {pnombre = tarea.nombre, pid_usuario=tarea.id_usuario, pcontenido= tarea.contenido });
        } 
        string query2 = "EXEC agregarTareayUser(@pidTarea, @pid_usuario)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pidTarea=id, pid_usuario=tarea.id_usuario});
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
            string query="SELECT * FROM tarea WHERE id_tarea IN (SELECT id_Tarea FROM tareaxUsuario WHERE id_usuario=@pidUsuario) AND estaborrada=0";
            tarea=connection.Query<Tarea>(query, new{pidUsuario=usuario.idUsuario}).ToList();
        }
        return tarea;
    }
    public static void eliminarTarea(int id_Tarea,int id_usuario){
        string query="UPDATE Tarea (estaBorrada) VALUES (1) WHERE id_tarea=@ptareaID AND @pidUsuario IN (SELECT id_usuario FROM Tarea WHERE id_tarea=@ptareaID)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea, pidUsuario=id_usuario});
        }
    }
      public static void terminarTarea(int id_Tarea){
        string query="UPDATE Tarea (estaFinalizada) VALUES (1) WHERE id_tarea=@ptareaID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea});
        }
    }

    public static void compartirTarea(int usuarioNuevo, int UsuarioOg, int id_Tarea)
    {
        string query = "INSERT INTO tareaxUsuario (id_tarea,id_Usuario) VALUES (@pidTarea,@pid_usuario) WHERE @pid_Og IN (SELECT id_usuario FROM Tarea WHERE id_tarea=@pidTarea)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {pidTarea=id_Tarea,pid_usuario=usuarioNuevo,pid_Og=UsuarioOg});
        }
    }

    public static void agregarALista(int id_Tarea,int lista){
        string query="UPDATE Tarea (id_lista) VALUES (@pidLista) WHERE id_tarea=@ptareaID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea,pidLista=lista});
        }
    }
}
