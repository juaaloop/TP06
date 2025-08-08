public class Tarea
{

    public int idTarea{get;set;}
    public int id_usuario{get;set;}
    public string nombre{get;set;}
    public int estaFinalizada{get;set;}
    public int estaBorrada{get;set;}
    public string contenido{get;set;}


    public void crearTarea(int Id_usuario, string Nombre,int final, int borrado, string contenidos){
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
