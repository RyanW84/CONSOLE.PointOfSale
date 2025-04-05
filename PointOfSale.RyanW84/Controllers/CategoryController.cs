using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.EntityFramework.RyanW84.Models;

using PointOfSale.EntityFramework.EntityFramework;

namespace PointOfSale.EntityFramework.RyanW84.Controllers;

internal class CategoryController
    {
    internal static void AddCategory(Category category)
        {
        using var db = new ProductsContext();

        db.Add(category);

        db.SaveChanges();
        }

    internal static List<Category> GetCategories( )
    {
    using var db = new ProductsContext();

    var categories = db.Categories.ToList();

    return categories;
    }
    }

