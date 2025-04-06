using System.ComponentModel.DataAnnotations;

namespace PointOfSale.EntityFramework.RyanW84;

internal class Enums
    {
    internal enum MainMenuOptions
        {
        [Display(Name = "Manage Categories")]
        ManageCategories,
        [Display(Name = "Manage Products")]
        ManageProducts,
        [Display(Name = "Quit")]
        Quit
        }

    internal enum CategoryMenu
        {
        [Display(Name = "Add Category")]
        AddCategory,
        [Display(Name = "Delete Category")]
        DeleteCategory,
        [Display(Name = "View Category")]
        ViewCategory,
        [Display(Name = "View All Categories")]
        ViewAllCategories,
        [Display(Name = "Update Category")]
        UpdateCategory,
        [Display(Name = "Go Back")]
        GoBack
        }

    internal enum ProductMenu
        {
        [Display(Name = "Add Product")]
        AddProduct,
        [Display(Name = "Delete Product")]
        DeleteProduct,
        [Display(Name = "Update Product")]
        UpdateProduct,
        [Display(Name = "View Product")]
        ViewProduct,
        [Display(Name = "View All Products")]
        ViewAllProducts,
        [Display(Name = "Go Back")]
        GoBack
        }
    }
