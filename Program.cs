namespace HandmadeClothesBoutique
{
    using System;

    // Custom exception class for product out of stock
    public class ProductOutOfStockException : Exception
    {
        public ProductOutOfStockException(string message) : base(message) { }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }

    public class DeliveryService
    {
        public bool PlaceOrder(Product product)
        {
            if (product.Stock <= 0)
            {
                throw new ProductOutOfStockException("Product is out of stock");
            }
            else
            {
                product.Stock--; // decrementing stop
                return true;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DeliveryService deliveryService = new DeliveryService();

            Console.Write("Enter the product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter the number of stocks: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Product product = new Product { Name = productName, Stock = stock };

            try
            {
                if (deliveryService.PlaceOrder(product))
                {
                    Console.WriteLine("Order placed successfully");
                }
            }
            catch (ProductOutOfStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
