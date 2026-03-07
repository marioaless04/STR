//Herencia Simple
using System;

class Animal
{
    public virtual void Sonido()
    {
        Console.WriteLine("El animal hace un sonido");
    }
}

class Perro : Animal
{
    public override void Sonido()
    {
        Console.WriteLine("El perro ladra");
    }
}

class Gato : Animal
{
    public override void Sonido()
    {
        Console.WriteLine("El gato hace miau");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal animal = new Animal();
        animal.Sonido(); // Output: El animal hace un sonido

        Perro perro = new Perro();
        perro.Sonido(); // Output: El perro ladra

        Gato gato = new Gato();
        gato.Sonido(); // Output: El gato hace miau
    }
}
