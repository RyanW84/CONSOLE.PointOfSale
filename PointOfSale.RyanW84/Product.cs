namespace PointOfSale.EntityFramework.RyanW84;

internal class Product
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } = 0;
    public int ProductId { get; set; }


    }

