using PointOfSale.EntityFramework.EntityFramework;
using PointOfSale.EntityFramework.RyanW84;

using Spectre.Console;

namespace PointOfSale.EntityFramework;

internal class ProductController
    {
    internal static void AddProduct()
        {
        var name = AnsiConsole.Ask<String>("Product's name:");
        using var db = new ProductsContext();
        db.Add(new Product { Name = name });
        db.SaveChanges();
        }

    internal static void DeleteProduct()
        {
        throw new NotImplementedException();
        }
    internal static void UpdateProduct()
        {
        throw new NotImplementedException();
        }

        internal static List<Product> GetProducts()
        {
        using var db = new ProductsContext();

        var products = db.Products.ToList(); //00:47

        return products;
        }
    internal static void ViewProduct()
        {
        throw new NotImplementedException();
        }

    internal static void ViewAllProducts()
        {
        throw new NotImplementedException();
        }







    }

