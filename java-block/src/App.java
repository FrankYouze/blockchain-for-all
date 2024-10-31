public class App {
    public static void main(String[] args) {
        Chai_wallet satoshi = new Chai_wallet();
        Chai_wallet bob = new Chai_wallet();
        Chai_wallet alice = new Chai_wallet();

        satoshi.sendMoney(50, bob.publicKey);
        bob.sendMoney(23, alice.publicKey);
        alice.sendMoney(5, bob.publicKey);

        System.out.println(Chai_chain.getInstance().toString());
    }
}

