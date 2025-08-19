using Microsoft.Data.SqlClient;
using Dapper;
public static class BDLista
{

    public static string connectionString = @"Server=localhost\SQLEXPRESS01;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";

    public static void agregarLista(string nombre)
    {
        string query = "INSERT INTO Lista (nombre) VALUES (@pnombre)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pnombre = nombre });
        }
    }
    public static void agregarALista(int id_tarea, int id_lista)
    {
        string query = "UPDATE Tarea SET id_lista=@pidLista WHERE id_tarea=@pidTarea";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pidLista = id_lista, pidTarea = id_tarea });
        }
    }
    public static void sacarDeLista(int id_tarea, int id_lista)
    {
        string query = "UPDATE Tarea SET id_lista=NULL WHERE id_tarea=@pidTarea";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pidLista = id_lista, pidTarea = id_tarea });
        }
    }
    public static void eliminarLista(int id_lista)
    {
        string query = "DELETE FROM Lista where id_lista=@pidLista";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { @pidLista = id_lista });
        }
    }
    public static string obtenerNombre(int id_lista)
    {
        string nombre;
        string query = "SELECT nombre FROM Lista where id_lista=@pidLista";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            nombre = connection.QueryFirstOrDefault<string>(query, new { @pidLista = id_lista });
        }
        return nombre;
    }
    public static List<Lista> obtenerListas()
    {
          List<Lista> listas=new List<Lista>(); 
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query="SELECT * FROM Lista ";
            listas=connection.Query<Lista>(query).ToList();
        }
        return listas;
    }
}
