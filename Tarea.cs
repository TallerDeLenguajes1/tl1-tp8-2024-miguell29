namespace clases;

public class Tarea
{
    private int tareaId;
    private string descripcion;
    private int duracion;

    public Tarea(int tareaId, string descripcion, int duracion)
    {
        this.tareaId = tareaId;
        this.descripcion = descripcion;
        this.duracion = duracion;
    }

    public int TareaId { get => tareaId; set => tareaId = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    public static void MostrarLista(List<Tarea> lista, string texto){
        Console.WriteLine(texto);
        foreach (var tarea in lista){
            Console.WriteLine($"Tarea {tarea.TareaId}: {tarea.Descripcion} ({tarea.Duracion})");
        }
    }
    public static bool BuscarTareaPorId(int id, List<Tarea> lista){
        bool encontrado = false;
        foreach (var tarea in lista){
            if (tarea.TareaId == id){
                encontrado = true;
                Console.WriteLine($"Tarea {tarea.TareaId}: {tarea.Descripcion} ({tarea.Duracion})");
            }
        }
        return encontrado;
    }
    public static bool BuscarTareaPorPalabra(string palabra, List<Tarea> lista){
        bool encontrado = false;
        foreach (var tarea in lista){
            if (tarea.Descripcion.Contains(palabra)){
                encontrado = true;
                Console.WriteLine($"Tarea {tarea.TareaId}: {tarea.Descripcion} ({tarea.Duracion})");
            }
        }
        return encontrado;
    }
}



