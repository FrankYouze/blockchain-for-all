class transaction:

    def __init__(self,amount,payer_address,payee_address):
        self.amount = amount
        self.payer_address = payer_address
        self.payee_address = payee_address

        self.tx = str(amount) + " from "+payer_address +" to "+ payee_address


tx1 = transaction(100,"ff8bcd","b8c5a9")
print(tx1.tx)