using System;

namespace Banks
{
    abstract class Account
    {
        public Bank CurrBank;
        public Client Owner;
        public DateTime creatTime;
        public double AccMoney;
        public double rate = 0;
        public int ID;
        private static int NextID = 1;
        public Account(Bank bank, Client owner)
        {
            CurrBank = bank;
            Owner = owner;
            creatTime = DateTime.Now;
            ID = NextID;
            NextID++;
        }
        public double GetInterest(double AccMoney, DateTime creatDate, double rate)
        {
            if (DateTime.Now.AddMonths(1) < creatTime)
            {
                var DaysPassed = Math.Abs((DateTime.Now - creatDate).TotalDays);
                return AccMoney * rate / 365 * Math.Truncate(DaysPassed) * rate / 365;
            }
            else
            {
                int NumMonths = (DateTime.Now.AddMonths(2).Month - creatDate.Month);
                return AccMoney * rate / 365 * NumMonths * rate / 365 * 31;
            }
        }
        public abstract void WithdrawMoney(double money);
        public abstract void DepositMoney(double money);
        public abstract void TranslateMoney(double money, int id);
    }
}
