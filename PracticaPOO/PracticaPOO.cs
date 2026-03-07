using System;

class PracticaPOO
{
    static void Main(string[] args)
{
    Garaje garaje = new Garaje();
    Coche coche1 = new Coche("Marca1", "Modelo1");
    Coche coche2 = new Coche("Marca2", "Modelo2");

    Random rnd = new Random();

    for (int i = 0; i < 2; i++)
    {
        if (garaje.aceptarCoche(coche1, "aceite"))
        {
            coche1.Motor.LitrosDeAceite += 10;
        }
        coche1.acumularAveria(rnd.NextDouble()*100);
        if (garaje.aceptarCoche(coche2, "otra averia"))
        {
            coche2.acumularAveria(rnd.NextDouble()*100);
            garaje.devolverCoche();
        }
        garaje.devolverCoche();
    }

    Console.WriteLine("Informacion de los coches");
    Console.WriteLine("Coche 1: ");
    Console.WriteLine($"Marca: {coche1.Marca}, Modelo: {coche1.Modelo}, Precio averias:{coche1.PrecioAcumulado}, Litros de aceite: {coche1.Motor.LitrosDeAceite}");
    Console.WriteLine("Coche 2: ");
    Console.WriteLine($"Marca: {coche2.Marca}, Modelo: {coche2.Modelo}, Precio averias:{coche2.PrecioAcumulado}, Litros de aceite: {coche2.Motor.LitrosDeAceite}");
}
}
