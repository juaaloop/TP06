public class Usuario{

    public int id_Usuario {get;set;}
    public string username{get;set;}
    public string password{get;set;}
    
    
    public void crearUsuario(string Nombre, string Password){
        username=Nombre;
        password=Password;
    }
}
