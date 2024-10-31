import rsa
from neural_tx import transaction
from neural_chain import neuralChain
class NeuralWallet:
    # publicKey,privateKey = rsa.newkeys(1024)

    def __init__(self):
        self.publicKey, self.privateKey = rsa.newkeys(1024)   # generate public and private key pair
        with open("public_key.pem","wb")  as f:
          f.write(self.publicKey.save_pkcs1('PEM'))
        with open("private_key.pem","wb")  as f:
          f.write(self.privateKey.save_pkcs1('PEM'))


    def send_money(self, amount,payee_publicKey): 
        transaction_data = transaction(amount, self.publicKey.save_pkcs1().decode(), payee_publicKey)
        enc_transaction = rsa.sign(transaction_data.tx.encode(), self.privateKey,"SHA-256")
        # print(transaction_data.tx)  # Sign transaction data with private key
        # print(enc_transaction)
        chain = neuralChain() 
        chain.addBlock(transaction= transaction_data.tx.encode(),senderPublicKey=self.publicKey.load_pkcs1(self.publicKey.save_pkcs1()),senderSignature=enc_transaction)
        return transaction_data.tx, enc_transaction
  # Return signed transaction data
       

    # def print(self):
        

    #     print(self.privateKey)


NeuralWallet().send_money(100,"1234578765432265432143")
NeuralWallet().send_money(10,"1234578765432iojerre265432143")


# print(privateKey)
