
public class Chai_tx {
    public double amount;
    public String payer; // public key
    public String payee; // public key

    public Chai_tx(double amount, String payer, String payee) {
        this.amount = amount;
        this.payer = payer;
        this.payee = payee;
    }

    @Override
    public String toString() {
        return "{\"amount\": " + amount + ", \"payer\": \"" + payer + "\", \"payee\": \"" + payee + "\"}";
    }
}


