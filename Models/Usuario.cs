public class Usuario{

    public string username {get;set;}
    public string password{get;set;}
    public int idUsuario{get;set;}
    
    
    public void crearUsuario(string Nombre, string Password){
        username=Nombre;
        password=Password;
    }
     public void agregarID(int id){
        idUsuario=id;
    }
}
