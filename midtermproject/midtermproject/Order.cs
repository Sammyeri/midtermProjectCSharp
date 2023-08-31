

namespace midtermproject
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Order(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}
