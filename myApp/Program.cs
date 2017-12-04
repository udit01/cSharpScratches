using System;
using System.Collections.Generic;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Welcome to the new era.");


            // var names = new List<string> { "John Jones", "Ana", "Felipe" };
            // foreach (var name in names)
            // {
            //     Console.WriteLine($"Hello {name.ToUpper()}!");
            // }
            var account = new BankAccount("Udit",1000);

            Console.WriteLine($"Account:{account.Number} was created by : {account.Owner} with initial balance {account.Balance}.");

            account.MakeWithdrawal(500, DateTime.Now, "Dummy payee" ,"Rent payment");
            // Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            // Console.WriteLine(account.Balance);

            // try {
            //     var invalidAccount = new BankAccount("invalid", -55);
            // } catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exception caught creating account with negative balance Line 31");
            //     Console.WriteLine(e.ToString());
            //     // What is the proper systax for below functionality?
            //     // e.printStackTrace();
            // }

            // // Test for a negative balance
            // try {
            //     account.MakeWithdrawal(750, DateTime.Now, "Hypothetical" ,"Attempt to overdraw");
            // } catch (InvalidOperationException e)
            // {
            //     Console.WriteLine("Exception caught trying to overdraw Line 42");
            //     Console.WriteLine(e.ToString());
            // }

            Console.WriteLine(account.GetAccountHistory());

        }
    }
}
