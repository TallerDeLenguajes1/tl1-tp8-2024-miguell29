namespace EspacioCalculadora;
/*
Cree la clase Calculadora que permita encadenar
operaciones sobre un mismo resultado guardado en un campo llamado dato, utilizando
los siguientes métodos.
● void Sumar(double termino)
● void Restar(double termino)
● void Multiplicar(double termino)
● void Dividir(double termino)
● void Limpiar()
*/
public class Calculadora
{
    private Double dato = 0;
    private List<Operacion> historial = new List<Operacion>();
    public Double Resultado { get => dato; }


    public void Menu(){
        Console.WriteLine("\tCalculadora V3");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Limpiar");
            Console.WriteLine("0. Salir");
    }
    public void Sumar(double termino){
        var suma = new Operacion(dato, termino, TipoOperacion.Suma);
        historial.Add(suma);
        dato += termino;
    }
    public void Restar(double termino){
        var operacion = new Operacion(dato, termino, TipoOperacion.Resta);
        historial.Add(operacion);
        dato -= termino;
    }
    public void Multiplicar(double termino){
        var operacion = new Operacion(dato, termino, TipoOperacion.Multiplicacion);
        historial.Add(operacion);
        dato *= termino;
    }
    public void Dividir(double termino){
        if(termino != 0){
            var operacion = new Operacion(dato, termino, TipoOperacion.Divicion);
            historial.Add(operacion);
            dato /= termino;
        }else
        {
            Console.WriteLine("ERROR - No se puede dividir por cero");
        }
    }
    public void Limpiar(){
        historial = new List<Operacion>();
        /*foreach (var operacion in historial)
        {
            historial.Remove(operacion);
        }*/
        dato = 0;
    }
    public void MostrarHistorial(){
        if (historial.Count == 0)
        {
            Console.WriteLine(dato);
        }else
        {
            Console.WriteLine("Historial de operaciones");
            foreach (var operacion in historial){
                operacion.MostrarOperacion();
            }
        }
    }
}