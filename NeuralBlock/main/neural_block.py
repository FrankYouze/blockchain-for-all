import hashlib
import time



class NeuralBlock:


    def __init__(self,prev_block_hash,transaction_list):
        self.prev_block_hash = prev_block_hash
        self.transaction_list = transaction_list
        self.block_time = round(time.time())

        self.block_data = "-".join(transaction_list)+ "-"+prev_block_hash
        self.block_hash = hashlib.sha256(self.block_data.encode()).hexdigest()
        

        hashlib.sha256()
        


somebloc = NeuralBlock("hash",["tx1", "tx2", "tx3", "tx4", "tx5"])

print(somebloc.block_hash)
print()
