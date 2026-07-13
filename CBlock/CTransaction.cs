namespace ConsoleApp1;

public class CTransaction
{
    public double amount;
    public String payer;
    public String payee;



    public CTransaction(double amount, String payer, String payee)
    {
        this.amount = amount;
        this.payer = payer;
        this.payee = payee;
    }

    public String toString()
    {
        return amount.ToString("C") + payee + payer;
    }
}