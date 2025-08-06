public class Tarea
{

    public int idTarea;
    public int id_usuario;
    public string nombre;
    public bool estaFinalizada;
    public bool estaBorrada;
    public string contenido;


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
