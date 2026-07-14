using System.Collections;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1;

public class CChain
{
  public static List<CBlock> chain;
  private static CChain instance;

  private CChain()
  {
    // chain = new ArrayList();
    chain.Add(new CBlock("Hello satoshi",new CTransaction(1000000.0,payee:"Satoshi",payer:"Nakamoto")));
  }

  public static CChain getInstance()
  {
    if (instance == null)
    {
      instance = new CChain();
    }
    return instance;
  }
  
  public CBlock getLastBlock()
  {
    return chain.Last(); //.get(chain.size() - 1);
  }


  public int mine(int nonce)
  {
    int solution = 1;
    Console.WriteLine("⛏️  mining...");

    while (true)
    {
      try
      {
        SHA256 digest = SHA256.Create();
        String data = nonce + solution + "";
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        byte[] hashBytes = digest.ComputeHash(dataBytes);

        if (hashBytes.ToString().StartsWith("00000"))
        {
          Console.WriteLine("solved:" + solution.ToString());
          return solution;

        }

        solution++;
      }catch(Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

  }

  public void addBlock(CTransaction transaction,PublicKey senderPublicKey,byte[] signature)
  {
    CBlock newBlock = new CBlock(getLastBlock().getHash(),transaction);
    mine(newBlock.nonce);
    chain.Add(newBlock);
  }

  public bool verifyTransaction(CTransaction transaction)
  {
return false;
  }
  
  // public void addBlock(Chai_tx transaction, PublicKey senderPublicKey, byte[] signature) {
  //   if (verifySignature(transaction, senderPublicKey, signature)) {
  //     Chai_block newBlock = new Chai_block(getLastBlock().getHash(), transaction);
  //     mine(newBlock.nonce);
  //     chain.add(newBlock);
  //   } else {
  //     System.out.println("Invalid signature, block rejected.");
  //   }
  // }
  //
  // private boolean verifySignature(Chai_tx transaction, PublicKey publicKey, byte[] signature) {
  //   try {
  //     Signature sig = Signature.getInstance("SHA256withRSA");
  //     sig.initVerify(publicKey);
  //     sig.update(transaction.toString().getBytes("UTF-8"));
  //     return sig.verify(signature);
  //   } catch (Exception e) {
  //     throw new RuntimeException(e);
  //   }
  // }
}