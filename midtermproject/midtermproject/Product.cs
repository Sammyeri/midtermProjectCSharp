
namespace midtermproject;

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public Product(string name, string category,string description,decimal price, int productID)
    {
        this.Name = name;
        this.Category = category;
        this.Description = description;
        this.Price = price;
        this.ProductId = productID;
    }
}
