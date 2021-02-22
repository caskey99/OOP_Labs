using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    class Bank
    {
        public List<Client> ClientList;
        public List<Transaction> TransactionsArchive;
        public string Name;
        public double Interest, Commission, Limit, Barrier, Rrat, Lrat;
        public string PropertyName
        {
            set
            {
                if (value != null)
                    Name = value;
                else
                    throw new Exception("Not correct Bank name!");
            }
            get { return Name; }
        }
        public double PropertyInterest
        {
            set
            {
                if (value >= 0 && value <= 100)
                    Interest = value;
            }
            get { return Interest; }
        }
        public double PropertyCommission
        {
            set
            {
                if (value >= 0 && value <= 100)
                    Commission = value;
            }
            get { return Commission; }
        }
        public double PropertyLimit
        {
            set
            {
                if (value >= 0)
                    Limit = value;
            }
            get { return Limit; }
        }
        public double PropertyBarrier
        {
            set
            {
                if (value >= 0)
                    Barrier = value;
            }
            get { return Barrier; }
        }
        public double PropertyRrat
        {
            set
            {
                if (value >= 0 && value <= 100)
                    Rrat = value;
            }
            get { return Rrat; }
        }
        public double PropertyLrat
        {
            set
            {
                if (value >= 0 && value <= 100)
                    Lrat = value;
            }
            get { return Lrat; }
        }

        public Bank(string name, double interest, double commission, double limit, double barrier, double rrat, double lrat)
        {
            PropertyName = name;
            PropertyInterest = interest;
            PropertyCommission = commission;
            PropertyLimit = limit;
            PropertyBarrier = barrier;
            PropertyRrat = rrat;
            PropertyLrat = lrat;
            ClientList = new List<Client>();
            TransactionsArchive = new List<Transaction>();
        }

        public void CreateDebitAaccount(Client human, double money)
        {
            if (money < 0)
                throw new Exception("Money < 0!");
            else
            {
                CheckingDuplicateClient(human);
                human.AccountsList.Add(new DebitAccount(this, human, money));
            }

        }

        public void CreateDepositAccount(Client human, double money, int day)
        {
            if (money < 0)
                throw new Exception("Money < 0!");
            else
            {
                CheckingDuplicateClient(human);
                human.AccountsList.Add(new DepositAccount(this, human, money, day));
            }
        }

        public void CreateCreditAccount(Client human, double money)
        {
            if (money < 0)
                throw new Exception("Money < 0!");
            else
            {
                CheckingDuplicateClient(human);
                human.AccountsList.Add(new CreditAccount(this, human, money));
            }
        }

        public void CheckingDuplicateClient(Client human)
        {
            var found = ClientList.Find(item => item.PassportNumber == human.PassportNumber);
            if (found == null)
                ClientList.Add(human);
        }

        public double GetDepInterest(double money)
        {
            if (money < Barrier)
                return Rrat;
            else
                return Lrat;
        }

        public void СancellationOfTransaction(int id)
        {
            var found = TransactionsArchive.Find(item => item.ID == id);
            if (found != null)
            {
                found.СancellationOfTransaction();
            }
            else
                throw new Exception("This transaction does not exist!");
        }

        public double RewindTime(DateTime time, Account currAcc)
        {
            var AccMoney = currAcc.AccMoney;
            var Rate = currAcc.rate;
            var Com = currAcc.CurrBank.PropertyCommission;
            if (Rate != 0)
            {
                if (DateTime.Now.AddMonths(1) < time)
                {
                    var DaysPassed = Math.Abs((DateTime.Now - time).TotalDays);
                    return AccMoney += AccMoney * Rate / 365 * Math.Truncate(DaysPassed) * Rate / 365;
                }
                else
                {
                    int NumMonths = 0, NumYear = 0;
                    if (DateTime.Now.Year != time.Year)
                    {
                        NumYear = DateTime.Now.Year + time.Year;
                        NumMonths = (time.Month + NumYear / 12) - DateTime.Now.Month;
                    }
                    else
                        NumMonths = (time.Month - DateTime.Now.Month);
                    return AccMoney += AccMoney * Rate / 365 * NumMonths * Rate / 365 * 31;
                }
            }
            else
            {
                if (AccMoney < 0)
                    return AccMoney * (1 + Com / 365);
                else
                    return AccMoney;
            }
        }

    }
}
