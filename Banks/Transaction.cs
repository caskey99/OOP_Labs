
namespace Banks
{
    public abstract class Transaction
    {
        public int ID;
        public double SumOfTransfer;
        public static int NextID = 1;
        public bool transactionСanceled = false;
        public abstract void СancellationOfTransaction();
    }
}
