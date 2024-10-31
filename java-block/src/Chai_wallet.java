import java.security.*;
import java.util.Base64;

public class Chai_wallet {
    private PrivateKey privateKey;
    public PublicKey publicKey;

    public Chai_wallet() {
        try {
            KeyPairGenerator keyGen = KeyPairGenerator.getInstance("RSA");
            keyGen.initialize(2048);
            KeyPair pair = keyGen.generateKeyPair();
            privateKey = pair.getPrivate();
            publicKey = pair.getPublic();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public void sendMoney(double amount, PublicKey payeePublicKey) {
        Chai_tx transaction = new Chai_tx(amount, Base64.getEncoder().encodeToString(publicKey.getEncoded()),
                Base64.getEncoder().encodeToString(payeePublicKey.getEncoded()));
        byte[] signature = signTransaction(transaction);
        Chai_chain.getInstance().addBlock(transaction, publicKey, signature);
    }

    private byte[] signTransaction(Chai_tx transaction) {
        try {
            Signature signature = Signature.getInstance("SHA256withRSA");
            signature.initSign(privateKey);
            signature.update(transaction.toString().getBytes("UTF-8"));
            return signature.sign();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
