using System.ComponentModel.DataAnnotations;


namespace KFHService.Models
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email
        { get; set; }
        public int Status { get; set; }
        public DateTime? DataOfBirth { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email
        { get; set; }
        public int Status { get; set; }
    }
}
