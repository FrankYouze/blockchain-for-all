using System.Collections;
using System.Security.Cryptography.X509Certificates;

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


  public void addBlock(CTransaction transaction,PublicKey senderPublicKey,byte[] signature)
  {
    CBlock newBlock = new CBlock(getLastBlock().getHash(),transaction);
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