using PointOfSale.EntityFramework.RyanW84;
using PointOfSale.RyanW84.RyanW84;


var context = new ProductsContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();


UserInterface.MainMenu();

