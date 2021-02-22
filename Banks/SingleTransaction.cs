using System;

namespace Banks 
{
    class SingleTransaction : Transaction
    {
        private Account account;
        public SingleTransaction(Account acc, double sum)
        {
            account = acc;
            SumOfTransfer = sum;
            ID = NextID;
            NextID++;
        }
        public override void СancellationOfTransaction()
        {
            if (transactionСanceled == true)
                throw new Exception("The transaction has already been canceled!");
            account.AccMoney -= SumOfTransfer;
            transactionСanceled = true;
        }
    }
}
