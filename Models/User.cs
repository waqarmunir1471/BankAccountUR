using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountUR.Models {
    public class User {
        [Key]
        public int UserId { get; set; }

        [Required (ErrorMessage = "First Name Must Required :")]
        [Display (Name = "First Name : ")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Last Name Must Required :")]
        [Display (Name = "First Name : ")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Email Must be Entered")]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email Address : ")]
        public string Email {get;set;}

        [Required(ErrorMessage="Password Must be Entered")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword {get;set;}

        public int BAccountId {get;set;}
        public List<BankAccount> BankAccounts {get;set;}


    }
}