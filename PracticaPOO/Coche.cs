using System;

class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precioAcumulado;

    public Coche(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.precioAcumulado = 0;
        this.motor = new Motor(0);
    }

    public Motor Motor
    {
        get { return motor; }
        set { motor = value; }
    }

    public string Marca
    {
        get { return marca;}
    }

    public string Modelo
    {
        get { return modelo; }
    }

    public double PrecioAcumulado
    {
        get { return precioAcumulado; }
    }

    public void acumularAveria(double importe)
    {
        precioAcumulado += importe;
    }
}