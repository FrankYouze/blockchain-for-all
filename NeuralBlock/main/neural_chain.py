from neural_block import NeuralBlock
from neural_tx import transaction
import rsa


class neuralChain:

    # neuralChain =  neuralChain()
    chain = []

    def __init__(self):
        self.chain = [NeuralBlock('genesis',[transaction(100,"ff8bcd","b8c5a9").tx]).block_hash]
   
    def getLastBlock(self):
        return self.chain[len(self.chain) - 1] + " is the last block"
    
    def addBlock(self,transaction,senderPublicKey,senderSignature):
        try:
           rsa.verify(transaction, senderSignature, senderPublicKey)
           self.chain.append(NeuralBlock(str(self.getLastBlock),transaction_list=[str(transaction)]))
           print("The signature is valid.")
        except rsa.VerificationError:
           print("The signature is invalid.")



    
    
cha1 = neuralChain()
print(cha1.getLastBlock())