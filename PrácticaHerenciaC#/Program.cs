using System;
using System.Collections.Generic;

class Hamburguesa
{
    protected string tipoPan;
    protected string tipoCarne;
    protected double precioBase;
    protected List<string> ingredientesAdicionales = new List<string>();

    public Hamburguesa(string tipoPan, string tipoCarne, double precioBase)
    {
        this.tipoPan = tipoPan;
        this.tipoCarne = tipoCarne;
        this.precioBase = precioBase;
    }

    public void AgregarIngrediente(string ingrediente, double precioAdicional)
    {
        if (ingredientesAdicionales.Count < 4)
        {
            ingredientesAdicionales.Add(ingrediente);
            precioBase += precioAdicional;
        }
        else
        {
            Console.WriteLine("No se pueden agregar más ingredientes adicionales.");
        }
    }

    public virtual void MostrarPrecio()
    {
        Console.WriteLine($"Hamburguesa: {tipoPan} - {tipoCarne}");
        Console.WriteLine("Ingredientes adicionales:");
        foreach (string ingrediente in ingredientesAdicionales)
        {
            Console.WriteLine($"- {ingrediente}");
        }
        Console.WriteLine($"Precio total: {precioBase}");
    }
    public double ObtenerPrecioBase()
    {
        return precioBase;
    }

    public List<string> ObtenerIngredientesAdicionales()
    {
        return ingredientesAdicionales;
    }
}

class HamburguesaSaludable : Hamburguesa
{
    public HamburguesaSaludable(string tipoPan, string tipoCarne, double precioBase) : base(tipoPan, tipoCarne, precioBase)
    {
       
    }

    public void AgregarIngredienteSaludable(string ingrediente, double precioAdicional)
    {
        if (ingredientesAdicionales.Count < 6)
        {
            ingredientesAdicionales.Add(ingrediente);
            precioBase += precioAdicional;
        }
        else
        {
            Console.WriteLine("No se pueden agregar más ingredientes adicionales.");
        }
    }

    public override void MostrarPrecio()
    {
        Console.WriteLine($"Hamburguesa Saludable: {tipoPan} - {tipoCarne}");
        Console.WriteLine("Ingredientes adicionales:");
        foreach (string ingrediente in ingredientesAdicionales)
        {
            Console.WriteLine($"- {ingrediente}");
        }
        Console.WriteLine($"Precio total: {precioBase}");
    }
}

class HamburguesaPremium : Hamburguesa
{
    public HamburguesaPremium(string tipoPan, string tipoCarne, double precioBase) : base(tipoPan, tipoCarne, precioBase)
    {
       
    }

    public override void MostrarPrecio()
    {
        Console.WriteLine($"Hamburguesa Premium: {tipoPan} - {tipoCarne}");
        Console.WriteLine($"Precio total: {precioBase}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        double precioBaseClasica = 250.0;
        double precioBaseSaludable = 325.0;
        double precioBasePremium = 400.0;

        Console.WriteLine("Bienvenido a Chimi MiBarriga del Sr. Billy Navaja");
        Console.WriteLine("Seleccione el tipo de hamburguesa:");
        Console.WriteLine($"1. Hamburguesa Clásica - ${precioBaseClasica}");
        Console.WriteLine($"2. Hamburguesa Saludable - ${precioBaseSaludable}");
        Console.WriteLine($"3. Hamburguesa Premium - ${precioBasePremium}");
        Console.Write("Ingrese su opción: ");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            int opcion;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        CrearHamburguesaClasica();
                        break;
                    case 2:
                        CrearHamburguesaSaludable();
                        break;
                    case 3:
                        CrearHamburguesaPremium();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida");
            }
        }
        else
        {
            Console.WriteLine("La entrada no es válida.");
        }
    }

    static void CrearHamburguesaClasica()
    {
        Hamburguesa hamburguesa = new Hamburguesa("Pan Normal", "Carne Normal", 250.0);
        SeleccionarIngredientes(hamburguesa);
    }

    static void CrearHamburguesaSaludable()
    {
        HamburguesaSaludable hamburguesa = new HamburguesaSaludable("Pan Integral", "Carne de Pavo", 325.0);
        SeleccionarIngredientes(hamburguesa);
    }

    static void CrearHamburguesaPremium()
    {
        HamburguesaPremium hamburguesa = new HamburguesaPremium("Pan de Oro", "Carne Angus", 400.0);
        hamburguesa.MostrarPrecio();
    }

    static void SeleccionarIngredientes(Hamburguesa hamburguesa)
    {
        Console.WriteLine("Seleccione los ingredientes adicionales (máximo 4):");
        Console.WriteLine("1. Lechuga (+$25.0)");
        Console.WriteLine("2. Tomate (+$25.0)");
        Console.WriteLine("3. Bacon (+$50.0)");
        Console.WriteLine("4. Pepinillo (+$10.0)");
        Console.WriteLine("5. Salir");

        double precioAdicional = 0.0;
        while (true)
        {
            Console.Write("Ingrese su opción (1-5): ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                int opcion;
                if (int.TryParse(input, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            hamburguesa.AgregarIngrediente("Lechuga", 25.0);
                            precioAdicional += 25.0;
                            break;
                        case 2:
                            hamburguesa.AgregarIngrediente("Tomate", 25.0);
                            precioAdicional += 25.0;
                            break;
                        case 3:
                            hamburguesa.AgregarIngrediente("Bacon", 50.0);
                            precioAdicional += 50.0;
                            break;
                        case 4:
                            hamburguesa.AgregarIngrediente("Pepinillo", 10.0);
                            precioAdicional += 10.0;
                            break;
                        case 5:
                            hamburguesa.MostrarPrecio();
                            return;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }

                    Console.WriteLine("Ingredientes adicionales seleccionados:");
                    hamburguesa.MostrarPrecio();
                    Console.WriteLine($"Total: {hamburguesa.ObtenerPrecioBase()}");
                    Console.WriteLine();
                    if (hamburguesa.ObtenerIngredientesAdicionales().Count >= 4)
                    {
                        Console.WriteLine("Máximo de ingredientes alcanzado.");
                        hamburguesa.MostrarPrecio();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("La entrada no es válida.");
                }
            }
        }
    }
}
