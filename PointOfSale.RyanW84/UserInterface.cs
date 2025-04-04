using System.ComponentModel.DataAnnotations;

using Spectre.Console;

namespace PointOfSale.EntityFramework.RyanW84;

internal class UserInterface
    {
    private static int stackId = 0;

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

        var isMenuRunning = true;

        var userInterface = new UserInterface();

        while (isMenuRunning)
            {
            Console.Clear() ;
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(MenuOptions)).Cast<MenuOptions>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case MenuOptions.AddProduct:
                ProductController.AddProduct();
                break;
                case MenuOptions.DeleteProduct:
                ProductController.DeleteProduct();
                break;
                case MenuOptions.UpdateProduct:
                ProductController.UpdateProduct();
                break;
                case MenuOptions.ViewProduct:
                ProductController.ViewProduct();
                break;
                case MenuOptions.ViewAllProducts:
                ProductController.ViewAllProducts();
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


    }
