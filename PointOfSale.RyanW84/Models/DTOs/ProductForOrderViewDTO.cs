using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.EntityFramework.RyanW84.Models.DTOs;

internal class ProductForOrderViewDTO
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    }

