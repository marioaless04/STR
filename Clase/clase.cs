using System;

public abstract class Beyblade
{
    public virtual string rotar()
    {
        return "Beyblade rotando";
    }
    public abstract string evolucionar()
    {
        return "Beyblade evolucionando";
    }
}
public class Pegasus : Beyblade
{
    public override string rotar()
    {
        return "Pegasus rotando";
    }
    public override string evolucionar()
    {
        return "Pegasus evolucionando";
    }
}
public class Virgo : Beyblade
{
    public override string rotar()
    {
        return "Virgo rotando";
    }
    public override string evolucionar()
    {
        retutn "Virgo evolucionando";
    }
}

class Program
{
   static void Main(string[] args)
   {
        Beyblade beyblade = new Beyblade();
        beyblade.rotar();
        beyblade.evolucionar();
 
        Pegasus pegasus= new Pegasus();
        pegasus.rotar();
        pegasus.evolucionar();
        
        Virgo virgo = new Virgo();
        virgo.rotar();
        virgo.evolucionar();
   }
}
