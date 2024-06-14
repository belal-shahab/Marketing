using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketing_api.Models;

public class Stock
{
    [Key]
    public int Id { get; set; }
    public Product Product { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public int Quanitty { get; set; }
}