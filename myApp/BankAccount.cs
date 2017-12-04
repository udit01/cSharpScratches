using System;
using System.Collections.Generic;


namespace myApp
{
    class BankAccount{

        private static int accountNumberSeed = 1234567890 ;
        private List<Transaction> allTransactions = new List<Transaction>();

        public string Number { get; }
        public string Owner { get; set;}
        public decimal Balance { // Iterate to eliminate chances of frauds, slow but secure
            get{
                decimal balance = 0;
                foreach(var item in allTransactions){
                    balance += item.Amount;
                }
                return balance;
            }
        }
        
        //Constructor of the bank account 
        public BankAccount(String name , decimal initialBalance){
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            
            this.Owner = name;
            MakeDeposit( initialBalance , DateTime.Now , "Initial Deposit balance");
            // this.Balance = initialBalance; 
            // shouldn't we verify that the initalBalance is positive ? --> done
        }        
        
        public void MakeDeposit(decimal amount , DateTime date, string note){
            if (amount<=0){
                throw new ArgumentOutOfRangeException(nameof(amount),"The deposit amount must be positive.");
            }
            var deposit = new Transaction(amount,date,note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount , DateTime date , string payee , string note){
            //what to do with the payee ? 
            
            if(amount<=0){
                throw new ArgumentOutOfRangeException(nameof(amount), "The withdrawl amount must be positive");
            }
            if(this.Balance - amount < 0){
                //Shouldn't we tell the user what is the current amount in their accounts which they can withdraw ?
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount,date,note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory(){
            //shouldn't we include things such as string and name and a heading ... Account history for::: etc ?
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach(var transaction in this.allTransactions){
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t\t{transaction.Amount}\t\t{transaction.Notes}");
            }

            return report.ToString();
        }
    }
}