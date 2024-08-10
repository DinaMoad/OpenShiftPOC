using Microsoft.EntityFrameworkCore;
using KFHService.Models;
namespace KFHService.Data
{
    public class ApplicationDbContext : DbContext
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public  DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }


    }
}
