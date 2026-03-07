using System;
using System.Collections.Generic;

public class Practica2
{
    public static void Main(string[] args)
    {
        Centralita centralita = new Centralita();
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Ingrese el numero de origen");
            string numOrigen = Console.ReadLine();

            Console.WriteLine("Ingrese el numero de destino");
            string numDestino = Console.ReadLine();

            Console.WriteLine("Ingrese la duracion de la llamada (en segundos)");
            double duracion = double.Parse(Console.ReadLine());

            int tipoLlamada;
            do
            {
                Console.WriteLine("Tipo de llamada (1: Local), (2: Provincial)");
                tipoLlamada = int.Parse(Console.ReadLine());
            } while (tipoLlamada != 1 && tipoLlamada != 2);

            Llamada llamada;
            if (tipoLlamada == 1)
            {
                llamada = new LlamadaLocal(numOrigen, numDestino, duracion);
            }
            else
            {
                Console.WriteLine("Ingrese la franja horaria a la que desee llamar (1, 2 o 3)");
                int franja = int.Parse(Console.ReadLine());

                llamada = new LlamadaProvincial(numOrigen, numDestino, duracion, franja);
            }

            centralita.RegistrarLlamada(llamada);

            Console.WriteLine("Desea registrar otra llamada? (1: Si), (2: No)");
            int respuesta = int.Parse(Console.ReadLine().ToUpper());
            continuar = respuesta == 1;
        }

        Console.WriteLine("Total de llamadas registradas: " + centralita.GetTotalLlamadas());
        Console.WriteLine("Total Facturado: " + centralita.GetTotalFacturado());
    }
}

public abstract class Llamada
{
    protected string numOrigen;
    protected string numDestino;
    protected double duracion;
    protected double precio;

    public Llamada(string numOrigen, string numDestino, double duracion)
    {
        this.numOrigen = numOrigen;
        this.numDestino = numDestino;
        this.duracion = duracion;
        this.precio = CalcularPrecio();
    }

    public string NumOrigen
    {
        get { return numOrigen; }
    }

    public string NumDestino
    {
        get { return numDestino; }
    }

    public double Duracion
    {
        get { return duracion; }
    }

    public double Precio
    {
        get { return precio; }
    }

    public abstract double CalcularPrecio();
}

public class LlamadaProvincial : Llamada
{
    private double precio1 = 0.20;
    private double precio2 = 0.0125;
    private double precio3 = 0.30;
    private int franja;

    public LlamadaProvincial(string numOrigen, string numDestino, double duracion, int franja) : base(numOrigen, numDestino, duracion)
    {
        this.franja = franja;

        if (franja == 1)
        {
            this.precio = precio1;
        }
        else if (franja == 2)
        {
            this.precio = precio2;
        }
        else
        {
            this.precio = precio3;
        }
    }

    public override double CalcularPrecio()
    {
        return duracion * precio;
    }
}

public class LlamadaLocal : Llamada
{
    private double precioLocal = 0.15;

    public LlamadaLocal(string numOrigen, string numDestino, double duracion) : base(numOrigen, numDestino, duracion)
    {
        this.precio = precioLocal;
    }

    public override double CalcularPrecio()
    {
        return duracion * precio;
    }
}

public class Centralita
{
    private List<Llamada> llamadas;

    public Centralita()
    {
        llamadas = new List<Llamada>();
    }

    public void RegistrarLlamada(Llamada llamada)
    {
        llamadas.Add(llamada);
    }

    public double GetTotalFacturado()
    {
        double totalFacturado = 0.0;
        foreach (var llamada in llamadas)
        {
            totalFacturado += llamada.CalcularPrecio();
        }
        return totalFacturado;
    }

    public int GetTotalLlamadas()
    {
        return llamadas.Count;
    }
}
