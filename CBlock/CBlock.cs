using System.Security.Cryptography;
using System.Text;
namespace ConsoleApp1;

public class CBlock
{
    public int nonce;
    public string prevHash;
    public CTransaction transaction;
    public long timestamp;


    public CBlock(
 string prevHash, CTransaction transaction)
    {    Random rand = new Random();
        this.nonce = rand.Next(999999999);
        this.prevHash = prevHash;
        this.transaction = transaction;
        timestamp = DateTime.Now.Millisecond; 

    }


    public String getHash()
    {
        try
        {
          SHA256  digest = SHA256.Create();
          String blockData = prevHash + transaction.toString() + nonce + timestamp;
          byte[] blockBytes = Encoding.UTF8.GetBytes(blockData);
          byte[] hashBytes = digest.ComputeHash(blockBytes);   //Hash(blockData);
          return Convert.ToBase64String(hashBytes);

        }
        catch (Exception e)
        {
            return "Error: " + e.Message;
        }


        return "";
    }

    // public String getHash() {
    //     try {
    //         MessageDigest digest = MessageDigest.getInstance("SHA-256");
    //         String dataToHash = prevHash + transaction.toString() + nonce + timestamp;
    //         byte[] hashBytes = digest.digest(dataToHash.getBytes("UTF-8"));
    //         StringBuilder buffer = new StringBuilder();
    //         for (byte b : hashBytes) {
    //             buffer.append(String.format("%02x", b));
    //         }
    //         return buffer.toString();
    //     } catch (Exception e) {
    //         throw new RuntimeException(e);
    //     }
    // }
    
}