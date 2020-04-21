using System;
using System.Transactions;
using System.ComponentModel.DataAnnotations;

namespace BankAccountUR.Models
{
    public class BankAccount
    {
        [Key]
        public int BAccountId {get;set;}
        
        [Required(ErrorMessage="Amount Must be ENtered")]
        [DataType(DataType.Currency)]
        [Display(Name="Deposit/WithDraw : ")]
        public int TAmount{get;set;}
        public DateTime TDate {get;set;} = DateTime.Now;
        public int UserId {get;set;}
        public User AccountCreator {get;set;}

    }
}