using PointOfSale.EntityFramework.EntityFramework;
using PointOfSale.EntityFramework.RyanW84;


var context = new ProductsContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();


UserInterface.MainMenu();

