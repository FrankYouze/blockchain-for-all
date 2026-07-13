

namespace ConsoleApp1;

public class CBlock
{
    public string nounce;
    public string prevHash;
    public CTransaction transaction;
    public long timestamp;
    
    
    public CBlock(
        string nounce,string prevHash,CTransaction transaction,long timestamp)
    {}
}