using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework.RyanW84.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Product
    {

    public int ProductId { get; set; }


    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
    }

