using System.Security.Cryptography;
using System.Text;
using System.Transactions;


namespace ConsoleApp1;

public class CWallet
{
    private String privateKey;
    public String publicKey;
    
    

    
    public CWallet()
    {
        try
        {
            RSA rsa = RSA.Create(2048);
            privateKey = rsa.ExportRSAPrivateKeyPem();
            publicKey = rsa.ExportRSAPublicKeyPem();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void SendCoin(double amount, string payeePubKey)
    {
        CTransaction tx = new CTransaction(amount,publicKey ,payeePubKey);
        byte[] signature = signTransaction(tx);
        // CChain.getInstance().addBlock(tx, publicKey, signature);
    }

    private byte[] signTransaction(CTransaction transaction)
    {
        try
        {

           byte[] txBytes = Encoding.UTF8.GetBytes(transaction.toString());
           using RSA privateKeyProvider = RSA.Create();
           privateKeyProvider.ImportFromPem(privateKey);
            byte[] signature = privateKeyProvider.SignData(txBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return signature;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}