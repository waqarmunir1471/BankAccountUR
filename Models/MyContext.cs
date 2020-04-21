using Microsoft.EntityFrameworkCore;

namespace BankAccountUR.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users {get;set;}
        public DbSet<BankAccount> BankAccounts {get;set;}
    }
}