using System.ComponentModel.DataAnnotations;

namespace Marketing_api.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ContactName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }
        
        public string? Address { get; set; }
        
        public ICollection<Purchase> Purchases { get; set; }
       public ICollection<Product> Products { get; set; }
    }
}
