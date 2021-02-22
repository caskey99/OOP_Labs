using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    class CreditAccount : Account
    {
        public double Commission;
        public double Limit;
        public enum CreditStatus
        {
            negative,
            positive
        }
        public CreditStatus status = CreditStatus.positive;
        public CreditAccount(Bank bank, Client owner, double money) : base(bank, owner)
        {
            AccMoney = money;
            Limit = bank.Limit;
            Commission = bank.Commission;
        }

        public override void WithdrawMoney(double money)
        {
            if (status == CreditStatus.negative)
                AccMoney *= (1 + Commission / 365);
            if (money < AccMoney + Limit && Owner.state == Client.ClientState.complete)
            {
                AccMoney -= money;
                var transaction = new SingleTransaction(this, -money);
                CurrBank.TransactionsArchive.Add(transaction);
            }
            else
                throw new Exception("The account does not have enough funds or the owner's status does not allow you to withdraw money!");
            status = СheckingTheStatus(AccMoney);
        }

        public override void DepositMoney(double money)
        {
            AccMoney += money;
            status = СheckingTheStatus(AccMoney);
            var transaction = new SingleTransaction(this, money);
            CurrBank.TransactionsArchive.Add(transaction);
        }

        public override void TranslateMoney(double money, int id)
        {
            Transaction transaction = null;
            if (Owner.state == Client.ClientState.complete && money <= AccMoney)
            {
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
                status = СheckingTheStatus(AccMoney);
            }
            else
                throw new Exception("There is no way to translate!");
            if (transaction != null)
            {
                CurrBank.TransactionsArchive.Add(transaction);
            }

        }

        public CreditStatus СheckingTheStatus(double AccMoney)
        {
            if (AccMoney >= 0)
                return status = CreditStatus.positive;
            else
                return status = CreditStatus.negative;
        }

    }
}
