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

}