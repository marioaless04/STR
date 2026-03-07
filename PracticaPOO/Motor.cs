using System;

class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.litros_de_aceite = 0;
        this.potencia = potencia;
    }

    public int LitrosDeAceite
    {
        get { return litros_de_aceite; }
        set { litros_de_aceite = value; }
    }

    public int Potencia
    {
        get { return potencia; }
        set { potencia = value; }
    }

}