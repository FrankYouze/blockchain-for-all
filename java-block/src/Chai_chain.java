import java.security.*;
import java.util.ArrayList;
import java.util.List;

public class Chai_chain {
    private static Chai_chain instance;
    private List<Chai_block> chain;

    private Chai_chain() {
        chain = new ArrayList<>();
        // Genesis block
        chain.add(new Chai_block("", new Chai_tx(100, "genesis", "satoshi")));
    }

    public static Chai_chain getInstance() {
        if (instance == null) {
            instance = new Chai_chain();
        }
        return instance;
    }

    public Chai_block getLastBlock() {
        return chain.get(chain.size() - 1);
    }

    public int mine(int nonce) {
        int solution = 1;
        System.out.println("⛏️  mining...");

        while (true) {
            try {
                MessageDigest digest = MessageDigest.getInstance("SHA-256");
                String data = nonce + solution + "";
                byte[] hashBytes = digest.digest(data.getBytes("UTF-8"));
                StringBuilder buffer = new StringBuilder();
                for (byte b : hashBytes) {
                    buffer.append(String.format("%02x", b));
                }
                if (buffer.toString().startsWith("0000")) {
                    System.out.println("Solved: " + solution);
                    return solution;
                }
                solution++;
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
        }
    }

    public void addBlock(Chai_tx transaction, PublicKey senderPublicKey, byte[] signature) {
        if (verifySignature(transaction, senderPublicKey, signature)) {
            Chai_block newBlock = new Chai_block(getLastBlock().getHash(), transaction);
            mine(newBlock.nonce);
            chain.add(newBlock);
        } else {
            System.out.println("Invalid signature, block rejected.");
        }
    }

    private boolean verifySignature(Chai_tx transaction, PublicKey publicKey, byte[] signature) {
        try {
            Signature sig = Signature.getInstance("SHA256withRSA");
            sig.initVerify(publicKey);
            sig.update(transaction.toString().getBytes("UTF-8"));
            return sig.verify(signature);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
