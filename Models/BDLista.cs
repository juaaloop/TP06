using Microsoft.Data.SqlClient;
using Dapper;
public static class BDLista
{

    public static string connectionString = @"Server=localhost;
    DataBase=TP06; Integrated Security=True; TrustServerCertificate=True;";

    public static void agregarLista(Lista lista)
    {
        string query = "INSERT INTO Lista (id_lista, nombre, id_usuarioOg) VALUES (@pidLista, @pnombre,@pusuario)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(query, new { pidLista=lista.idLista,pnombre = lista.nombre, pusuario=lista.idUsu});
        }
    }
}
