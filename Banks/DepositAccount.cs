using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    class DepositAccount : Account
    {
        public double RateMoney = 0;
        private DateTime DepositTerm;
        public DateTime PropertyDepositTerm
        {
            set
            {
                if (value != null)
                    DepositTerm = value;
            }
            get { return DepositTerm; }
        }
        public DepositAccount(Bank bank, Client owner, double money, int depositTerm) : base(bank, owner)
        {
            AccMoney = money;
            if (depositTerm >= 0)
            {
                PropertyDepositTerm = DateTime.Now.AddDays(depositTerm);
                rate = bank.GetDepInterest(money);
            }
            else
                throw new Exception("Days can't be negative!");
        }

        override public void WithdrawMoney(double money)
        {
            if(DateTime.Now >= DepositTerm)
            {
                if (DateTime.Now.AddMonths(1) >= creatTime.AddMonths(1))
                    AccMoney += GetInterest(AccMoney, creatTime, rate);
                else
                {
                    RateMoney += GetInterest(AccMoney, creatTime, rate);
                    creatTime = DateTime.Now;
                }
                if (Owner.state == Client.ClientState.complete && money <= AccMoney)
                {
                    AccMoney -= money;
                    var transaction = new SingleTransaction(this, -money);
                    CurrBank.TransactionsArchive.Add(transaction);
                }
                else
                    throw new Exception("The account does not have enough funds or the owner's status does not allow you to withdraw money!");
            }
            else
                throw new Exception("you can't withdraw money before the date" + DepositTerm);
        }

        override public void DepositMoney(double money)
        {
            AccMoney += money;
            var transaction = new SingleTransaction(this, money);
            CurrBank.TransactionsArchive.Add(transaction);
        }

        override public void TranslateMoney(double money, int id)
        {
            Transaction transaction = null;
            if (DateTime.Now >= DepositTerm)
            {
                if (Owner.state == Client.ClientState.complete && money <= AccMoney)
                {
                    if (DateTime.Now.AddMonths(1) >= creatTime.AddMonths(1))
                    {
                        AccMoney += GetInterest(AccMoney, creatTime, rate);
                    }
                    else
                    {
                        RateMoney += GetInterest(AccMoney, creatTime, rate);
                        creatTime = DateTime.Now;
                    }
                    AccMoney -= money;
                    Account found = null;
                    foreach (var jtem in CurrBank.ClientList)
                    {
                        found = jtem.AccountsList.Find(item => item.ID == id);
                        if (found != null)
                            break;
                    }
                    if (found != null)
                    {
                        found.AccMoney += money;
                        transaction = new DoubleTransaction(this, found, money);
                    }
                    else
                    {
                        throw new Exception("The specified account was not found!");
                    }
                }
                else
                    throw new Exception("There is no way to translate!");
            }
            if (transaction != null)
                CurrBank.TransactionsArchive.Add(transaction);
        }

    }
}
