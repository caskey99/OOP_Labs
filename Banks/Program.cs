using System;
using System.Linq;

namespace Banks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating banks
            Bank Sberbank = new Bank("Sberbank", 3.65, 3.65, 30000, 1000, 3.65, 7.30);
            Bank VTB = new Bank("VTB", 2, 5, 20000, 100000, 3.65, 7.30);

            //Create Client "Bob" - Name, Surname
            var CBuilder = new ClientBuilder();
            CBuilder.EnterName("Bob");
            CBuilder.EnterSurname("Harold");
            var Bob = CBuilder.GetClient();

            //Create Client "Bob" - Name, Surname, Address, PassportNumber
            CBuilder.EnterName("Li");
            CBuilder.EnterSurname("Yu");
            CBuilder.EnterAddress("Bolshaya Morskaya Street, 1");
            CBuilder.EnterPassportNumber(6594855);
            var Li = CBuilder.GetClient();

            //Create Debit Acc for Bob
            Sberbank.CreateDebitAaccount(Bob, 1000);
            Sberbank.CreateDebitAaccount(Li, 2000);

            Console.WriteLine("TEST Translate");
            //TEST Translate
            Console.WriteLine(Bob.AccountsList.Last().AccMoney + " " + Bob.AccountsList.Last().ID);
            Console.WriteLine(Li.AccountsList.Last().AccMoney + " " + Li.AccountsList.Last().ID);
            Console.WriteLine();
            Li.AccountsList.Last().TranslateMoney(300, 1);
            Li.AccountsList.Last().TranslateMoney(700, 1);
            Console.WriteLine(Bob.AccountsList.Last().AccMoney + " " + Bob.AccountsList.Last().ID);
            Console.WriteLine(Li.AccountsList.Last().AccMoney + " " + Li.AccountsList.Last().ID);

            Console.WriteLine();
            Console.WriteLine("Test Cancellation Transaction");
            foreach (var item in Sberbank.TransactionsArchive)
            {
                Console.WriteLine(item.ID + " = " + item.SumOfTransfer);
            }
            Console.WriteLine();
            Sberbank.СancellationOfTransaction(1);
            Console.WriteLine(Bob.AccountsList.Last().AccMoney + " " + Bob.AccountsList.Last().ID);
            Console.WriteLine(Li.AccountsList.Last().AccMoney + " " + Li.AccountsList.Last().ID);

            Console.WriteLine();
            //Test time machine
            Console.WriteLine(Li.AccountsList.Last().AccMoney + " " + Li.AccountsList.Last().ID);
            Console.WriteLine(Sberbank.RewindTime(DateTime.Now.AddYears(1), Li.AccountsList.Last()));
        }
    }
}
