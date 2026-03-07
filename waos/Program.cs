
IBanking banking;
ATM_banking =new ATM();

Console.WriteLine("DIgite el Canal: 1=amt, 2=IB");
int canal = Convert.ToInt32(Console.ReadLine(""));

switch(canal)
{
    case 1:
    banking=new ATM();
}