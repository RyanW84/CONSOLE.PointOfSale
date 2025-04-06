using System.ComponentModel.DataAnnotations;

using PointOfSale.EntityFramework.RyanW84.Models;
using PointOfSale.EntityFramework.RyanW84.Services;

using Spectre.Console;

using static PointOfSale.EntityFramework.RyanW84.Enums;

namespace PointOfSale.EntityFramework.RyanW84;

static internal class UserInterface
    {


    //Menu Methods
    private static string GetEnumDisplayName(Enum enumValue) //Enums weren't showing their display name, this fixes it
        {
        var displayAttribute =
            enumValue
                .GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

        if (displayAttribute == null)
            {
            Console.WriteLine("No Enum display names found");
            }

        return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
        }

    internal static void MainMenu()
        {
        Console.Clear();

        bool isMenuRunning = true;

        while (isMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(MainMenuOptions)).Cast<MainMenuOptions>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case MainMenuOptions.ManageCategories:
                CategoriesMenu();
                break;
                case MainMenuOptions.ManageProducts:
                ProductsMenu();
                break;
                case MainMenuOptions.Quit:
                isMenuRunning = false;
                Console.WriteLine("Thank you for using our E.P.O.S App");
                break;
                default:
                Console.WriteLine("Please enter a correct option");
                Console.ReadKey();
                MainMenu();
                break;

                }
            }
        }

    internal static void CategoriesMenu()
        {
        bool isCategoryMenuRunning = true;

        while (isCategoryMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenu>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(CategoryMenu)).Cast<CategoryMenu>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case CategoryMenu.AddCategory:
                CategoryService.InsertCategory();
                break;
                case CategoryMenu.DeleteCategory:
                CategoryService.DeleteCategory();
                break;
                case CategoryMenu.UpdateCategory:
                CategoryService.UpdateCategory();
                break;
                case CategoryMenu.ViewCategory:
                CategoryService.GetCategory();
                break;
                case CategoryMenu.ViewAllCategories:
                CategoryService.GetCategories();
                break;
                case CategoryMenu.GoBack:
                isCategoryMenuRunning = false;
                break;
                default:
                Console.Write("Please choose a valid option (Press Any Key to continue:");
                Console.ReadLine();
                CategoriesMenu();
                break;
                }
            }
        }

    internal static void ProductsMenu()
        {
        bool isProductMenuRunning = true;

        while (isProductMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ProductMenu>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(ProductMenu)).Cast<ProductMenu>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case ProductMenu.AddProduct:
                ProductService.InsertProduct();
                break;
                case ProductMenu.DeleteProduct:
                ProductService.DeleteProduct();
                break;
                case ProductMenu.UpdateProduct:
                ProductService.UpdateProduct();
                break;
                case ProductMenu.ViewProduct:
                ProductService.GetProduct();
                break;
                case ProductMenu.ViewAllProducts:
                ProductService.GetProducts();
                break;
                case ProductMenu.GoBack:
                isProductMenuRunning = false;
                break;
                default:
                Console.Write("Please choose a valid option (Press Any Key to continue:");
                Console.ReadLine();
                ProductsMenu();
                break;
                }
            }
        }

    internal static void ShowProduct(Product product)
        {
        var panel = new Panel($"ID: {product.ProductId} \nName: {product.Name} \nPrice: £{product.Price} \nCategory: {product.Category.Name}");
        panel.Header = new PanelHeader("** Product Info **");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();

        }

    static internal void ShowProductTable(List<Product> products)
        {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Name");
        table.AddColumn("Price £");
        table.AddColumn("Category");

        foreach (var product in products)
            {
            table.AddRow(
            product.ProductId.ToString(),
            product.Name,
            product.Price.ToString(),
            product.Category.Name
            );
            }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        }

    internal static void ShowCategoryTable(List<Category> categories)
        {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Name");

        foreach (Category category in categories)
            {
            table.AddRow(
            category.CategoryId.ToString(),
            category.Name
            );
            }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        }

    internal static void ShowCategory(Category category)
        {

        var panel = new Panel($"ID: {category.CategoryId} \nName: {category.Name} \nProduct Count: {category.Products.Count}");
        panel.Header = new PanelHeader($"** {category.Name} **");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();


        }
    }

