using System.ComponentModel.DataAnnotations;

namespace BankAccountUR.Models
{
    public class Login
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email : ")]
        [Required(ErrorMessage="Email Must be Entered")]
        public string LoginEmail {get;set;}

        [DataType(DataType.Password)]
        [Display(Name="Password : ")]
        [Required(ErrorMessage="Password Must be Entered")]
        public string LoginPassword {get;set;}
        public int UserId {get;set;}
    }
}