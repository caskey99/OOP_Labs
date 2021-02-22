using System;

namespace Banks
{
    class DoubleTransaction : Transaction
    {
        Account senderAcc;
        Account recipientAcc;

        public DoubleTransaction(Account sender, Account recipient, double sum)
        {
            senderAcc = sender;
            recipientAcc = recipient;
            SumOfTransfer = sum;
            ID = NextID;
            NextID++;
        }

        public override void СancellationOfTransaction()
        {
            if (transactionСanceled == true)
                throw new Exception("The transaction has already been canceled!");
            senderAcc.AccMoney += SumOfTransfer;
            recipientAcc.AccMoney -= SumOfTransfer;
            transactionСanceled = true;
        }
    }
}
