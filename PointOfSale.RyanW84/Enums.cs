using System.ComponentModel.DataAnnotations;

namespace PointOfSale.EntityFramework.RyanW84;

enum MenuOptions
    {
    [Display(Name = "Add Category")]
    AddCategory,
    [Display(Name = "Delete Category")]
    DeleteCategory,
    [Display(Name = "View All Categories")]
    ViewAllCategories,
    [Display(Name = "Update Category")]
    UpdateCategory,
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
    [Display(Name = "Quit")]
    Quit
    }

