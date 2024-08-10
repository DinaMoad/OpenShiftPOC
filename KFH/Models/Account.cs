using System.ComponentModel.DataAnnotations;

namespace KFH.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public String Action { get; set; }
    }
}
