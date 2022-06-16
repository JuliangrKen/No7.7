class Order<TDelivery, TStruct>
    where TDelivery : Delivery
    where TStruct : struct
{
    public TDelivery? Delivery;
    public TStruct? Struct;
    public int Number = OrderEditing.GenerateNumber();

    public string? Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery?.Address);
    }

    // ... Другие поля
}
abstract class Delivery
{
    public string? Address;
    public Delivery(string Address)
    {
        this.Address = Address;
    }
    public Delivery() { }
}
class HomeDelivery : Delivery
{
    string CourierName;
    public HomeDelivery(string Address, string CourierName) : base (Address)
    {
        this.CourierName = CourierName;
    }
}
abstract class NoHomeDelivery : Delivery
{
    /* ... */
    public NoHomeDelivery() : base() { /* ... */ }
}
class PickPoints
{
    public string PPAdress;
    public string[] DeliveryCompanies;
    public PickPoints(string PPAdress)
    {
        this.PPAdress = PPAdress;
        this.DeliveryCompanies = AppealToCompanies(PPAdress);
    }
    private string[] AppealToCompanies(string PPAdress)
    {
        /* ... */
        string[] companies = { "" };
        return companies;
    }
}
class Shops
{ 
    /* ... */
}

class PickPointDelivery : NoHomeDelivery
{
    /* ... */

    public PickPointDelivery(string Address) : base()
    {
        Address = dad();
    }
    private string dad()
    {
        PickPoints pp = new PickPoints(Address);
        return pp.DeliveryCompanies[0];
    }
}

class ShopDelivery : NoHomeDelivery
{
    /* ... */
    public ShopDelivery(string Address) : base() { /* ... */ }
}

class Product
{

}
// Класс с набором инструментов для изменения информации заказа:
static class OrderEditing
{
    public static void ChangeAddress(ref Delivery delivery, string NewAddress)
    {
        delivery.Address = NewAddress;
    }

    public static int GenerateNumber()
    {
        Random random = new Random();
        int number = random.Next(10000000, 99999999);
        /* тут логика для проверки должна быть, но её опустим */
        return number;
    }
}