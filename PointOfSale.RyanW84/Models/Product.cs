using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework.RyanW84.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Product
    {
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    }

