using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PointOfSale.EntityFramework.RyanW84.Controllers;
using PointOfSale.EntityFramework.RyanW84.Models;

using Spectre.Console;

namespace PointOfSale.EntityFramework.RyanW84.Services;

internal class CategoryService
    {
    internal static void InsertCategory()
        {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Catergory's name:");

        CategoryController.AddCategory(category);

        }

        internal static void GetCategories()
        {
        var categories =CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
       
        }

    internal static int GetCategoryOptionInput()
        {
        var categories
        = CategoryController.GetCategories();
        var categoriesArray = categories.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose Category")
        .AddChoices(categoriesArray));
        var id = categories.Single(x => x.Name == option).CategoryId;
     

        return id;
        }
    }

