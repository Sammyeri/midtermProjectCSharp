

namespace midtermproject
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; } 
        public List<Product> Cart { get; set; }

        public Order(Product product, int quantity)
        {
            this.Cart = new List<Product>();
            
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}
