using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework.RyanW84.Models;


internal class Category
    {
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public List<Product> Products { get; set; }
    }

