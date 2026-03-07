using System;
using System.Collections.Generic;

public class Repaso
{
    public static void Main(string[] args)
    {
        List<Autobus> autobuses = new List<Autobus>(); 

        bool continuar = true;
        while (continuar)
        {
            int tipoBus;
            do
            {
                Console.WriteLine("Ingrese el tipo de Autobus (1: Voladora), (2: OMSA), (3: Premium)");
                tipoBus = int.Parse(Console.ReadLine());
            } while (tipoBus != 1 && tipoBus != 2 && tipoBus != 3);

            Console.WriteLine("Ingrese la cantidad de pasajeros:");
            int cantidadPasajeros = int.Parse(Console.ReadLine());

            Autobus autobus = null;
            if (tipoBus == 1)
            {
                autobus = new Voladora();
            }
            else if (tipoBus == 2)
            {
                autobus = new OMSA();
            }
            else if (tipoBus == 3)
            {
                autobus = new Premium();
            }

            if (autobus != null)
            {
                if (cantidadPasajeros <= autobus.capacidad)
                {
                    autobus.PasajesVendidos(cantidadPasajeros);
                    autobuses.Add(autobus); 
                    Console.WriteLine("Asientos disponibles en " + autobus.tipo + ": " + (autobus.capacidad - autobus.pasajeros));
                }
                else
                {
                    Console.WriteLine("No hay suficientes asientos disponibles.");
                }
            }

            Console.WriteLine("Desea ingresar otro pasajero? (1: Si), (2: No)");
            int respuesta = int.Parse(Console.ReadLine());
            continuar = respuesta == 1;
        }

        Console.WriteLine("\nInformación de los autobuses:");
        foreach (var bus in autobuses)
        {
            MostrarInformacionAutobus(bus);
        }
    }

 public static void MostrarInformacionAutobus(Autobus autobus)
{
    Console.WriteLine("Tipo: " + autobus.tipo);
    Console.WriteLine("Ruta: " + autobus.ruta);
    Console.WriteLine("Tarifa: " + autobus.tarifa);
    Console.WriteLine("Capacidad: " + autobus.capacidad);
    Console.WriteLine("Asientos disponibles: " + (autobus.capacidad - autobus.pasajeros)); 
    Console.WriteLine("Aire acondicionado: " + (autobus.aire ? "Sí" : "No"));
    Console.WriteLine("Comodidad: " + autobus.comodidad);
    Console.WriteLine("Puntualidad: " + autobus.puntualidad);
    Console.WriteLine("Total pagado: " + autobus.totalPagado);
    Console.WriteLine();
}

}

public abstract class Autobus
{
    public string tipo { get; protected set; }
    public string ruta { get; protected set; }
    public decimal tarifa { get; protected set; }
    public int capacidad { get; protected set; }
    public bool aire { get; protected set; }
    public string comodidad { get; protected set; }
    public string puntualidad { get; protected set; }
    public decimal totalPagado { get; protected set; }
    public int pasajeros { get; protected set; }

    public Autobus(string tipo, string ruta, decimal tarifa, int capacidad, bool aire, string comodidad, string puntualidad)
    {
        this.tipo = tipo;
        this.ruta = ruta;
        this.tarifa = tarifa;
        this.capacidad = capacidad;
        this.comodidad = comodidad;
        this.aire = aire;
        this.puntualidad = puntualidad;
        this.totalPagado = 0;
        this.pasajeros = 0; 
    }

    public abstract void PasajesVendidos(int cantidadPasajeros);
}

public class Voladora : Autobus
{
    public Voladora() : base("Voladora", "Duarte a San Isidro", 10.0m, 55, false, "baja", "baja") { }

    public override void PasajesVendidos(int cantidadPasajeros)
    {
        if (cantidadPasajeros <= capacidad)
        {
            pasajeros += cantidadPasajeros;
            totalPagado = pasajeros * tarifa;
        }
    }
}

public class OMSA : Autobus
{
    public OMSA() : base("OMSA", "Corredor 27", 15.0m, 45, true, "media", "media") { }

    public override void PasajesVendidos(int cantidadPasajeros)
    {
        if (cantidadPasajeros <= capacidad)
        {
            pasajeros += cantidadPasajeros;
            totalPagado = pasajeros * tarifa;
        }
    }
}

public class Premium : Autobus
{
    public Premium() : base("Premium", "Corredor 27 a Cancela", 20.0m, 45, true, "alta", "alta") { }

    public override void PasajesVendidos(int cantidadPasajeros)
    {
        if (cantidadPasajeros <= capacidad)
        {
            pasajeros += cantidadPasajeros;
            totalPagado = pasajeros * tarifa;
        }
    }
}
