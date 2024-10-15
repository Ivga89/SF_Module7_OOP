internal class Program
{
    private static void Main(string[] args)
    {
        Address addressHD = new Address("Moscow", "Lenina", 10);
        HomeDelivery homeDelivery = new HomeDelivery(addressHD, "Ivan Ivanich");
        homeDelivery.DeliveryData();

        Address addressPP = new Address("Ekb", "Stroiteley", 13);
        PickPointDelivery pickPointDelivery = new PickPointDelivery(addressPP);
        pickPointDelivery.DeliveryData();

        Address addressSD = new Address("Ekb", "Stroiteley", 13);
        ShopDelivery shopDelivery = new ShopDelivery(addressSD, "Monetka");
        shopDelivery.DeliveryData();


        List<Product> products = new List<Product>();
        Product product1 = new Product("milk", 100);
        products.Add(product1);
        Product product2 = new Product("bred", 30);
        products.Add(product2);

        var order = new Order<HomeDelivery>(homeDelivery, 1, "Home Delivery products", products);
        order.OrderData();
        Console.WriteLine();
    }

    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }
        public int house { get; set; }
        public Address(string city, string street, int house)
        {
            this.city = city;
            this.street = street;
            this.house = house;
        }
        public override string ToString()
        {
            return $"Город: {city} улица {street} {house}";
        }
    }

    public abstract class Delivery
    {
        public Address address { get; set; }
        public Delivery(Address address)
        {
            this.address = address;
        }
        public abstract void DeliveryData();
    }

    public class HomeDelivery : Delivery
    {
        public string courierName { get; set; }
        public HomeDelivery(Address address, string courierName) : base(address)
        {
            this.courierName = courierName;
        }
        public override void DeliveryData()
        {
            Console.WriteLine($"Доставка на дом, по адресу: {address.ToString()} курьером {courierName}");
        }
    }

    public class PickPointDelivery : Delivery
    {
        public PickPointDelivery(Address address) : base(address)
        {
            base.address = address;
        }
        public override void DeliveryData()
        {
            Console.WriteLine($"Доставка в пункт выдачи, по адресу: {address.ToString()}");
        }
    }

    public class ShopDelivery : Delivery
    {
        public string shopName { get; set; }
        public ShopDelivery(Address address, string shopName) : base(address)
        {
            this.shopName = shopName;
        }

        public override void DeliveryData()
        {
            Console.WriteLine($"Доставка в постамат магазина {shopName}, по адресу: {address.ToString()}");
        }
    }

    public class Product
    {
        public string productName { get; set; }
        public decimal price { get; set; }

        public Product(string productName, decimal price)
        {
            this.productName = productName;
            this.price = price;
        }
        public override string ToString()
        {
            return $"{productName}: {price}р.";
        }
    }

    public class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery delivery { get; set; }
        public int number { get; set; }
        public string description { get; set; }
        public List<Product> products { get; set; }

        public Order(TDelivery delivery, int number, string description, List<Product> products)
        {
            this.delivery = delivery;
            this.number = number;
            this.description = description;
            this.products = products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void OrderData()
        {
            Console.Write($"\n{description} №{number}: ");
            foreach (var product in products)
            {
                Console.Write($"{product.ToString()}, ");
            }
        }
    }

}

