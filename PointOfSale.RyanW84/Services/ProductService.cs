using PointOfSale.EntityFramework.RyanW84.Controllers;
using PointOfSale.EntityFramework.RyanW84.Models;

using Spectre.Console;

namespace PointOfSale.EntityFramework.RyanW84.Services;

internal class ProductService
    {
    internal static void InsertProduct()
        {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Product's name:");
        product.Price = AnsiConsole.Ask<decimal>("Product's price:");
        product.CategoryId = CategoryService.
       GetCategoryOptionInput().CategoryId;

        ProductController.AddProduct(product);
        }
    internal static void DeleteProduct()
        {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
        }
    internal static void UpdateProduct()
        {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update Product Name?") ?
        AnsiConsole.Ask<string>("Product's new name: ")
        : product.Name;

        product.Price = AnsiConsole.Confirm("Update Product Price?") ?
       AnsiConsole.Ask<decimal>("Product's new price: ")
       : product.Price;
        product.Category = AnsiConsole.Confirm("Update Category?") ?
        CategoryService.GetCategoryOptionInput() : product.Category; 

        ProductController.UpdateProduct(product);
        }
    internal static void GetProduct()
        {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
        }
    internal static void GetProducts()
        {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
        }
    static private Product GetProductOptionInput()
        {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose Product")
        .AddChoices(productsArray));
        var id = products.Single(x => x.Name == option).ProductId;
        var product = ProductController.GetProductById(id);

        return product;
        }
    }

