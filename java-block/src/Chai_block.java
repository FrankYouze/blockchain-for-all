import java.security.MessageDigest;

public class Chai_block {
    public int nonce;
    public String prevHash;
    public Chai_tx transaction;
    public long timestamp;

    public Chai_block(String prevHash, Chai_tx transaction) {
        this.nonce = (int) (Math.random() * 999999999);
        this.prevHash = prevHash;
        this.transaction = transaction;
        this.timestamp = System.currentTimeMillis();
    }

    public String getHash() {
        try {
            MessageDigest digest = MessageDigest.getInstance("SHA-256");
            String dataToHash = prevHash + transaction.toString() + nonce + timestamp;
            byte[] hashBytes = digest.digest(dataToHash.getBytes("UTF-8"));
            StringBuilder buffer = new StringBuilder();
            for (byte b : hashBytes) {
                buffer.append(String.format("%02x", b));
            }
            return buffer.toString();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
