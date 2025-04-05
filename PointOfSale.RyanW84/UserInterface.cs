using System.ComponentModel.DataAnnotations;

using PointOfSale.EntityFramework.RyanW84.Models;
using PointOfSale.EntityFramework.RyanW84.Services;

using Spectre.Console;

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
                new SelectionPrompt<MenuOptions>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(MenuOptions)).Cast<MenuOptions>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case MenuOptions.AddCategory:
                CategoryService.InsertCategory();
                break;
                case MenuOptions.ViewAllCategories:
                CategoryService.GetCategories();
                break;
                case MenuOptions.AddProduct:
                ProductService.InsertProduct();
                break;
                case MenuOptions.DeleteProduct:
                ProductService.DeleteProduct();
                break;
                case MenuOptions.UpdateProduct:
                ProductService.UpdateProduct();
                break;
                case MenuOptions.ViewProduct:
                ProductService.GetProduct();
                break;
                case MenuOptions.ViewAllProducts:
                ProductService.GetProducts();
                break;
                case MenuOptions.Quit:
                isMenuRunning = false;
                Console.WriteLine("Thank you for using our E.P.O.S software\nGoodbye!");
                break;
                default:
                Console.Write("Please choose a valid option (Press Any Key to continue:");
                Console.ReadLine();
                MainMenu();
                break;

                }
            }
        }

    internal static void ShowProduct(Product product)
        {
        var panel = new Panel($"ID: {product.ProductId} \nName: {product.Name} \nPrice: {product.Price}");
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
        table.AddColumn("Price");

        foreach (var product in products)
            {
            table.AddRow(
            product.ProductId.ToString(),
            product.Name,
            product.Price.ToString());
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
        }
    
