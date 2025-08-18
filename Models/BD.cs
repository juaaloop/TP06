using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
{

    public static string connectionString = @"Server=localhost\SQLEXPRESS01;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";

    public static void agregarTarea(string nombre, string contenido, int idU)
    {
        int id;
        string query = "EXEC agregarTarea @pnombre, @pid_usuario,@pcontenido";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            id = connection.QueryFirstOrDefault<int>(query, new { pnombre = nombre, pid_usuario = idU, pcontenido = contenido });
        }
        agregarATabla(id, idU);
      
    }
    public static void agregarATabla(int idTarea, int idUsu)
    {
          string query = "EXEC agregarTareayUser @pidTarea, @pid_usuario";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pidTarea=idTarea, pid_usuario=idUsu});
        }
    }
    public static void modificarTarea(int idtarea,string contenido, int idUsuario)
    {
        string query = "UPDATE Tarea SET contenido=@pcontenido WHERE id_tarea=@ptareaID AND id_usuarioog=@pidUsuario";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {pcontenido= contenido, pTareaID=idtarea, pidUsuario=idUsuario });
        }
    }
    public static List<Tarea> levantarTarea(int idUsuario){
        
        List<Tarea> tarea=new List<Tarea>(); 
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query="SELECT * FROM tarea WHERE id_tarea IN (SELECT id_Tarea FROM tareaxUsuario WHERE id_usuario=@pidUsuario) AND estaborrada=0";
            tarea=connection.Query<Tarea>(query, new{pidUsuario=idUsuario}).ToList();
        }
        return tarea;
    }
    public static void eliminarTarea(int id_Tarea,int id_Usuario){
        string query="UPDATE Tarea SET estaBorrada=1 WHERE id_tarea=@ptareaID AND @pidUsuario=id_usuarioog";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { ptareaID = id_Tarea, pidUsuario = id_Usuario });
        }
    }
      public static void terminarTarea(int id_Tarea){
        string query="UPDATE Tarea SET estaFinalizada=1 WHERE id_tarea=@ptareaID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new {ptareaID=id_Tarea});
        }
    }

    public static void compartirTarea(int usuarioNuevo, int id_Tarea)
    {
        string query = "EXEC agregarTareayUser @pidTarea, @pid_usuario";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pidTarea = id_Tarea, pid_usuario = usuarioNuevo });
        }
    }

}
