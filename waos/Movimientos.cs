public class Movimientos
{
    public int IdMovimientos { get; set; }
    public int CostumerID {get; set;}

    public DateTime FechaMovimiento {get; set;}

    public string Descripcion {get; set;}

    public string TipoMovimiento {get; set;}

    public decimal Monto {get; set;}

    public string Estado {get; set;}
}