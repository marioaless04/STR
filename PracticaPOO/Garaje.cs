using System;

class Garaje
{
    private Coche coche;
    private string averia;
    private int cochesAtendidos;

    public bool aceptarCoche(Coche coche, string averia)
    {
        if (this.coche != null)
        {
            return false;
        }
        else
        {
            this.coche = coche;
            this.averia = averia;
            cochesAtendidos++;
            return true;
        }
    }
    
    public void devolverCoche()
    {
        coche = null;
        averia = null;
    }
}