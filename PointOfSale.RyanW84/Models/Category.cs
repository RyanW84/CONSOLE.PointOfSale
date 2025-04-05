using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework.RyanW84.Models;

[Index(nameof(Name), IsUnique = true)]

internal class Category
    {
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Product> Products { get; set; }
    }

