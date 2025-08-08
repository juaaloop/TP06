public class Tarea
{

    public int idTarea{get;set;}
    public int id_usuario{get;set;}
    public string nombre{get;set;}
    public bool estaFinalizada{get;set;}
    public bool estaBorrada{get;set;}
    public string contenido{get;set;}


    public crearTarea(string Id_usuario, string Nombre,bool final, bool borrado, string contenidos){
        id_usuario=Id_usuario;
        nombre=Nombre;
        estaFinalizada=final;
        estaBorrada=borrado;
        contenido=contenidos;
    }
    public void agregarId(int id){
        idTarea=id;
    }
}
