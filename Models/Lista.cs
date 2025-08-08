public class Lista{

    public int idLista {get;set;}
    public string nombre{get;set;}
    public int idUsu {get;set;}

    public void crearLista(int id, string Nombre, int IdUsu){
        idLista=id;
        nombre=Nombre;
        idUsu=IdUsu;
    }
}
