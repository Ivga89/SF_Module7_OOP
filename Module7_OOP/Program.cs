internal class Program
{
    private static void Main(string[] args)
    {
        Address address = new Address("Moscow", "Lenina", 10);
        HomeDelivery homeDelivery = new HomeDelivery(address, "Ivan Ivanich");
        homeDelivery.DeliveryStatus();


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
        public abstract void DeliveryStatus();
    }

    public class HomeDelivery : Delivery
    {
        public string courierName { get; set; }
        public HomeDelivery(Address address, string courierName) : base(address)
        {
            this.courierName = courierName;
        }
        public override void DeliveryStatus()
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
        public override void DeliveryStatus()
        {
            Console.WriteLine($"Доставка в пункт выдачи, по адресу: {address.ToString()}");
        }
    }

    

}