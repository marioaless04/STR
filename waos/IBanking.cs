public interface IBanking
{
    void Deposit(int amount, Customer customer);
    
    void Withdraw(int amount, Customer customer);

    int Inquiere(int CostumerID);

    list<Movimientos> movimientos(int CostumerID);
    DetalleTransaccion detalleTransaccion(int IdMovimientos);
    int Pago(int CostumerID);
}