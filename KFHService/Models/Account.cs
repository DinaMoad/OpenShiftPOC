using System.ComponentModel.DataAnnotations;

namespace KFHService.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
        public String Action { get; set; }
    }
}
