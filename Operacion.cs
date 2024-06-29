namespace EspacioCalculadora;

public class Operacion
{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacion;

    public Operacion (double anterior, double nuevo, TipoOperacion tipoOperacion){
        resultadoAnterior = anterior;
        NuevoValor = nuevo;
        operacion = tipoOperacion;
    }

    public double Resultado { get => resultadoAnterior;}
    public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
    
    public void MostrarOperacion(){
        switch (operacion)
        {
            case TipoOperacion.Suma:
            Console.WriteLine($"{resultadoAnterior} + {nuevoValor} = {resultadoAnterior + nuevoValor}");
            break;
            case TipoOperacion.Resta:
            Console.WriteLine($"{resultadoAnterior} - {nuevoValor} = {resultadoAnterior - nuevoValor}");
            break;
            case TipoOperacion.Multiplicacion:
            Console.WriteLine($"{resultadoAnterior} * {nuevoValor} = {resultadoAnterior * nuevoValor}");
            break;
            case TipoOperacion.Divicion:
            Console.WriteLine($"{resultadoAnterior} / {nuevoValor} = {resultadoAnterior / nuevoValor}");
            break;
        }
    }
}