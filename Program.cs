using System.Data.Common;
using System.Runtime.InteropServices;
using clases;
internal class Program
{
    private static void Main(string[] args)
    {
        int id = 1000;
        int opcion;
        string entrada;
        int tareasTotales;
        var listaTareasPendientes = new List<Tarea>();
        var listaTareasRealizadas = new List<Tarea>();
        Random random = new Random();
        tareasTotales = random.Next(10);

        for (int i = 0; i < tareasTotales; i++)
        {
            var tarea = new Tarea(id++,$"Tarea {i}, (generada automáticamente)",random.Next(10,101));
            listaTareasPendientes.Add(tarea);
        }

        Console.Clear();
        Menu.Show();

        do
        {
            entrada = Console.ReadLine();
            if (int.TryParse(entrada,out opcion))
            {
                switch (opcion)
                {
                    case 1 :
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("Ingrese una descripcion para la tarea:");
                        entrada = Console.ReadLine();
                        var tarea = new Tarea(id++,entrada,random.Next(10,101));
                        listaTareasPendientes.Add(tarea);
                        Console.WriteLine("Tarea creada exitosamente.");
                        Console.WriteLine("Desea agregar otra tarea? (1)Si (2)No");
                        entrada = Console.ReadLine();
                        if (!int.TryParse(entrada,out opcion) && opcion != 2 && opcion != 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Opcion invalida.");
                            continue;                    
                        }
                    } while (opcion == 1);
                    break;


                    case 2:
                    Tarea.MostrarLista(listaTareasPendientes,"Lista de tareas pendientes:");
                    Console.WriteLine("Ingrese el id de la tarea que desea marcar como completada");
                    entrada = Console.ReadLine();
                    bool tareaEncontrada = false;
                    if (int.TryParse(entrada,out opcion)){
                        foreach (var tarea in listaTareasPendientes)
                        {
                            if (tarea.TareaId == opcion)
                            {
                                listaTareasRealizadas.Add(tarea);
                                listaTareasPendientes.Remove(tarea);
                                Console.WriteLine("Tarea marcada como completada.");
                                tareaEncontrada = true;
                                break;
                            }
                        }
                    }else
                    {
                        Console.Clear();
                        Console.WriteLine("Opcion invalida.");
                    }
                    if (!tareaEncontrada)
                    {
                        Console.Clear();
                        Console.WriteLine("Tarea no encontrada");
                    }
                    break;

                    case 3:Console.Clear();
                    Tarea.MostrarLista(listaTareasRealizadas,"Lista de tareas completadas:");
                    Console.WriteLine("----------------------------------");
                    Tarea.MostrarLista(listaTareasPendientes,"Lista de tareas pendientes");
                    Console.WriteLine("----------------------------------");
                    break;

                    case 4:
                    bool encontrada = false;
                    Console.WriteLine("Ingrese el Id de la tarea o ingrese una palabra clave para buscar la tarea.");
                    entrada = Console.ReadLine();
                    if (int.TryParse(entrada,out opcion))
                    {
                        if (!Tarea.BuscarTareaPorId(opcion,listaTareasPendientes))
                        {
                            encontrada = Tarea.BuscarTareaPorId(opcion,listaTareasRealizadas);
                        }else
                        {
                            encontrada = true;
                        }
                    }else
                    {
                        if (!Tarea.BuscarTareaPorPalabra(entrada, listaTareasPendientes))
                        {
                            encontrada = Tarea.BuscarTareaPorPalabra(entrada, listaTareasRealizadas);
                        }else
                        {
                            Tarea.BuscarTareaPorPalabra(entrada, listaTareasRealizadas);
                            encontrada = true;
                        }
                    }
                    if (!encontrada){
                        Console.Clear();
                        Console.WriteLine("Tarea no encontrada");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;
                    
                    case 5:
                    Console.WriteLine("Saliendo...");
                    break;

                    default:
                    Console.Clear();
                    Console.WriteLine("Opcion no valida");
                    break;
                }
            }else
            {
                Console.Clear();
                Console.WriteLine("Opcion invalida");
                Menu.Show();
            }
        } while (opcion != 5);

    }

}