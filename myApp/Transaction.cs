using System;

namespace myApp
{
    public class Transaction{

        //In this class shouldn't we impleent who is paying to whom ? Like from which bank account string to which ?

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }
        
        public Transaction(decimal amount , DateTime date, string note){
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
    
}