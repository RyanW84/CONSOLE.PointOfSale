using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PointOfSale.EntityFramework.EntityFramework;
using PointOfSale.EntityFramework.RyanW84.Models;

namespace PointOfSale.EntityFramework.RyanW84.Controllers;

internal class OrderController
    {
    internal static void AddOrder(List <OrderProduct> orders)
        {
        using var db = new ProductsContext();

        db.OrderProducts.AddRange(orders);

        db.SaveChanges();
        }

    internal static List<Order> GetOrders( )
    {
    using var db = new ProductsContext();
    var ordersList = db.Orders
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .ThenInclude(p => p.Category)
        .ToList();

    return ordersList;
    }
    }

