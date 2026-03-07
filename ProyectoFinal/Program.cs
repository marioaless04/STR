using System;
using System.Collections.Generic;

class Program
{
    static List<JugadorActual> jugadoresActivos = new List<JugadorActual>();
    static List<JugadorRetirado> jugadoresRetirados = new List<JugadorRetirado>();

    static void Main(string[] args)
    {
        while (true)
        {
            // Menú
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Agregar un jugador activo");
            Console.WriteLine("2. Agregar un jugador retirado");
            Console.WriteLine("3. Editar un jugador activo");
            Console.WriteLine("4. Editar un jugador retirado");
            Console.WriteLine("5. Ver las estadísticas de un jugador activo");
            Console.WriteLine("6. Ver las estadísticas de un jugador retirado");
            Console.WriteLine("7. Comparar las estadísticas entre 2 jugadores activos");
            Console.WriteLine("8. Comparar las estadísticas entre 2 jugadores retirados");
            Console.WriteLine("9. Comparar las estadísticas entre un jugador activo y un jugador retirado");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Agregar un jugador activo
                    JugadorActual jugadorActual = CrearJugadorActual();
                    jugadoresActivos.Add(jugadorActual);
                    Console.WriteLine("Se agregó el jugador activo correctamente.");
                    break;
                case "2":
                    // Agregar un jugador retirado
                    JugadorRetirado jugadorRetirado = CrearJugadorRetirado();
                    jugadoresRetirados.Add(jugadorRetirado);
                    Console.WriteLine("Se agregó el jugador retirado correctamente.");
                    break;
                case "3":
                    // Editar un jugador activo
                    EditarJugador(jugadoresActivos);
                    break;
                case "4":
                    // Editar un jugador retirado
                    EditarJugador(jugadoresRetirados);
                    break;
                case "5":
                    // Ver las estadísticas de un jugador activo
                    VerEstadisticasJugador(jugadoresActivos);
                    break;
                case "6":
                    // Ver las estadísticas de un jugador retirado
                    VerEstadisticasJugador(jugadoresRetirados);
                    break;
                case "7":
                    // Comparar las estadísticas entre 2 jugadores activos
                    CompararEstadisticasJugadores(jugadoresActivos);
                    break;
                case "8":
                    // Comparar las estadísticas entre 2 jugadores retirados
                    CompararEstadisticasJugadores(jugadoresRetirados);
                    break;
                case "9":
                    // Comparar las estadísticas entre un jugador activo y un jugador retirado
                    CompararEstadisticasJugadores(jugadoresActivos, jugadoresRetirados);
                    break;
                case "10":
                    // Salir del programa
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    // Método para crear un nuevo jugador activo
    static JugadorActual CrearJugadorActual()
    {
        Console.WriteLine("Creando un nuevo jugador activo:");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Nacionalidad: ");
        string nacionalidad = Console.ReadLine();

        string posicion;
        while (true)
        {
            Console.WriteLine("Posiciones disponibles:");
            Console.WriteLine("- Portero (POR)");
            Console.WriteLine("- Defensa (DEF)");
            Console.WriteLine("- Medio (MED)");
            Console.WriteLine("- Delantero (DEL)");
            Console.Write("Seleccione una posición (escriba la abreviatura entre paréntesis): ");
            string posicionInput = Console.ReadLine().ToUpper();

            switch (posicionInput)
            {
                case "POR":
                    posicion = "Portero";
                    break;
                case "DEF":
                    posicion = "Defensa";
                    break;
                case "MED":
                    posicion = "Medio";
                    break;
                case "DEL":
                    posicion = "Delantero";
                    break;
                default:
                    Console.WriteLine("Opción de posición no válida. Por favor, seleccione una posición válida.");
                    continue; // Permite volver a solicitar la selección de posición
            }
            break; // Si la selección de posición es válida, salir del bucle
        }

        Console.Write("Goles: ");
        int goles = int.Parse(Console.ReadLine());
        Console.Write("Asistencias: ");
        int asistencias = int.Parse(Console.ReadLine());

        return new JugadorActual(nombre, nacionalidad, posicion, goles, asistencias);
    }

    // Método para crear un nuevo jugador retirado
    static JugadorRetirado CrearJugadorRetirado()
    {
        Console.WriteLine("Creando un nuevo jugador retirado:");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Nacionalidad: ");
        string nacionalidad = Console.ReadLine();

        string posicion;
        while (true)
        {
            Console.WriteLine("Posiciones disponibles:");
            Console.WriteLine("- Portero (POR)");
            Console.WriteLine("- Defensa (DEF)");
            Console.WriteLine("- Medio (MED)");
            Console.WriteLine("- Delantero (DEL)");
            Console.Write("Seleccione una posición (escriba la abreviatura entre paréntesis): ");
            string posicionInput = Console.ReadLine().ToUpper();

            switch (posicionInput)
            {
                case "POR":
                    posicion = "Portero";
                    break;
                case "DEF":
                    posicion = "Defensa";
                    break;
                case "MED":
                    posicion = "Medio";
                    break;
                case "DEL":
                    posicion = "Delantero";
                    break;
                default:
                    Console.WriteLine("Opción de posición no válida. Por favor, seleccione una posición válida.");
                    continue; // Permite volver a solicitar la selección de posición
            }
            break; // Si la selección de posición es válida, salir del bucle
        }

        Console.Write("Goles Totales: ");
        int golesTotales = int.Parse(Console.ReadLine());
        Console.Write("Asistencias Totales: ");
        int asistenciasTotales = int.Parse(Console.ReadLine());

        return new JugadorRetirado(nombre, nacionalidad, posicion, golesTotales, asistenciasTotales);
    }

    // Método para editar las estadísticas de un jugador
    static void EditarJugador<T>(List<T> jugadores) where T : Jugador
    {
        Console.WriteLine("Ingrese el nombre del jugador que desea editar:");
        string nombre = Console.ReadLine();
        T jugador = BuscarJugadorPorNombre(jugadores, nombre);

        if (jugador != null)
        {
            Console.WriteLine($"Editando las estadísticas de {nombre}:");
            Console.WriteLine("Ingrese el nuevo número de goles:");
            if (int.TryParse(Console.ReadLine(), out int nuevosGoles))
            {
                jugador.Goles = nuevosGoles;
                Console.WriteLine("Ingrese el nuevo número de asistencias:");
                if (int.TryParse(Console.ReadLine(), out int nuevasAsistencias))
                {
                    jugador.Asistencias = nuevasAsistencias;
                    Console.WriteLine($"Las estadísticas de {nombre} han sido actualizadas:");
                    Console.WriteLine($"Nuevo número de goles: {jugador.Goles}");
                    Console.WriteLine($"Nuevo número de asistencias: {jugador.Asistencias}");
                }
                else
                {
                    Console.WriteLine("Entrada inválida para asistencias.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida para goles.");
            }
        }
        else
        {
            Console.WriteLine("Jugador no encontrado en la lista.");
        }
    }

    // Método para visualizar las estadísticas de un jugador
    static void VerEstadisticasJugador<T>(List<T> jugadores) where T : Jugador
    {
        Console.Write("Ingrese el nombre del jugador para ver sus estadísticas: ");
        string nombre = Console.ReadLine();
        T jugador = BuscarJugadorPorNombre(jugadores, nombre);
        if (jugador != null)
        {
            Console.WriteLine($"Estadísticas del jugador {nombre}:");
            Console.WriteLine($"Nacionalidad: {jugador.Nacionalidad}");
            Console.WriteLine($"Posición: {jugador.Posicion}");
            Console.WriteLine($"Goles: {jugador.Goles}");
            Console.WriteLine($"Asistencias: {jugador.Asistencias}");
        }
        else
        {
            Console.WriteLine("Jugador no encontrado en la lista.");
        }
    }

    // Método para comparar las estadísticas de dos jugadores
    static void CompararEstadisticasJugadores<T>(List<T> jugadores) where T : Jugador
    {
        Console.WriteLine("Ingrese el nombre del primer jugador:");
        string nombre1 = Console.ReadLine();
        T jugador1 = BuscarJugadorPorNombre(jugadores, nombre1);

        Console.WriteLine("Ingrese el nombre del segundo jugador:");
        string nombre2 = Console.ReadLine();
        T jugador2 = BuscarJugadorPorNombre(jugadores, nombre2);

        if (jugador1 != null && jugador2 != null)
        {
            // Comparación de estadísticas
            Console.WriteLine($"Comparando las estadísticas de {nombre1} y {nombre2}:");
            Console.WriteLine($"Goles: {nombre1} tiene {jugador1.Goles} goles, {nombre2} tiene {jugador2.Goles} goles");
            Console.WriteLine($"Asistencias: {nombre1} tiene {jugador1.Asistencias} asistencias, {nombre2} tiene {jugador2.Asistencias} asistencias");

            // Más goles
            if (jugador1.Goles > jugador2.Goles)
            {
                Console.WriteLine($"{nombre1} tiene más goles que {nombre2}");
            }
            else if (jugador1.Goles < jugador2.Goles)
            {
                Console.WriteLine($"{nombre2} tiene más goles que {nombre1}");
            }
            else
            {
                Console.WriteLine($"Ambos jugadores tienen la misma cantidad de goles");
            }

            // Más asistencias
            if (jugador1.Asistencias > jugador2.Asistencias)
            {
                Console.WriteLine($"{nombre1} tiene más asistencias que {nombre2}");
            }
            else if (jugador1.Asistencias < jugador2.Asistencias)
            {
                Console.WriteLine($"{nombre2} tiene más asistencias que {nombre1}");
            }
            else
            {
                Console.WriteLine($"Ambos jugadores tienen la misma cantidad de asistencias");
            }
        }
        else
        {
            Console.WriteLine("Uno o ambos jugadores no encontrados en la lista.");
        }
    }

    // Método para comparar las estadísticas de un jugador activo con un jugador retirado
    static void CompararEstadisticasJugadores<T, U>(List<T> jugadoresActivos, List<U> jugadoresRetirados)
        where T : JugadorActual
        where U : JugadorRetirado
    {
        Console.WriteLine("Ingrese el nombre del jugador activo:");
        string nombreActivo = Console.ReadLine();
        T jugadorActivo = BuscarJugadorPorNombre(jugadoresActivos, nombreActivo);

        Console.WriteLine("Ingrese el nombre del jugador retirado:");
        string nombreRetirado = Console.ReadLine();
        U jugadorRetirado = BuscarJugadorPorNombre(jugadoresRetirados, nombreRetirado);

        if (jugadorActivo != null && jugadorRetirado != null)
        {
            // Comparación de estadísticas
            Console.WriteLine($"Comparando las estadísticas de {nombreActivo} (activo) y {nombreRetirado} (retirado):");
            Console.WriteLine($"Goles: {nombreActivo} tiene {jugadorActivo.Goles} goles, {nombreRetirado} tiene {jugadorRetirado.Goles} goles");
            Console.WriteLine($"Asistencias: {nombreActivo} tiene {jugadorActivo.Asistencias} asistencias, {nombreRetirado} tiene {jugadorRetirado.Asistencias} asistencias");

            // Más goles
            if (jugadorActivo.Goles > jugadorRetirado.Goles)
            {
                Console.WriteLine($"{nombreActivo} tiene más goles que {nombreRetirado}");
            }
            else if (jugadorActivo.Goles < jugadorRetirado.Goles)
            {
                Console.WriteLine($"{nombreRetirado} tiene más goles que {nombreActivo}");
            }
            else
            {
                Console.WriteLine($"Ambos jugadores tienen la misma cantidad de goles");
            }

            // Más asistencias
            if (jugadorActivo.Asistencias > jugadorRetirado.Asistencias)
            {
                Console.WriteLine($"{nombreActivo} tiene más asistencias que {nombreRetirado}");
            }
            else if (jugadorActivo.Asistencias < jugadorRetirado.Asistencias)
            {
                Console.WriteLine($"{nombreRetirado} tiene más asistencias que {nombreActivo}");
            }
            else
            {
                Console.WriteLine($"Ambos jugadores tienen la misma cantidad de asistencias");
            }
        }
        else
        {
            Console.WriteLine("Uno o ambos jugadores no encontrados en la lista.");
        }
    }

    // Método para buscar un jugador por su nombre en la lista
    static T BuscarJugadorPorNombre<T>(List<T> jugadores, string nombre) where T : Jugador
    {
        foreach (T jugador in jugadores)
        {
            if (jugador.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return jugador;
            }
        }
        return default(T); // Retornamos el valor predeterminado si el jugador no se encuentra
    }
}

// Clase base para un jugador
class Jugador
{
    public string Nombre { get; set; }
    public string Nacionalidad { get; set; }
    public string Posicion { get; set; }
    public int Goles { get; set; }
    public int Asistencias { get; set; }
}

// Clase para un jugador activo
class JugadorActual : Jugador
{
    public JugadorActual(string nombre, string nacionalidad, string posicion, int goles, int asistencias)
    {
        Nombre = nombre;
        Nacionalidad = nacionalidad;
        Posicion = posicion;
        Goles = goles;
        Asistencias = asistencias;
    }
}

// Clase para un jugador retirado
class JugadorRetirado : Jugador
{
    public JugadorRetirado(string nombre, string nacionalidad, string posicion, int golesTotales, int asistenciasTotales)
    {
        Nombre = nombre;
        Nacionalidad = nacionalidad;
        Posicion = posicion;
        Goles = golesTotales;
        Asistencias = asistenciasTotales;
    }
}

