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
// Класс с некоторыми иновациями для некоторых пользователей
class TestOrder<TDelivery, TStruct> : Order<TDelivery, TStruct>
    where TDelivery : Delivery
    where TStruct : struct
{
    public TestOrder()
    {
        /* *** */
        Number.GenerateNumber();
        /* *** */
    }
    /* *** */
}
abstract class Delivery
{
    public string? Address;
    protected Delivery(string Address)
    {
        this.Address = Address;
    }
    protected Delivery() { }
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
    protected void Log() { }
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
        Address = SortCompanies();
    }
    private string SortCompanies()
    {
        PickPoints pp = new PickPoints(Address);
        return pp.DeliveryCompanies[0];
    }
    protected new void Log() { }
}

class ShopDelivery : NoHomeDelivery
{
    /* ... */
    public ShopDelivery(string Address) : base() { /* ... */ }
    protected new void Log() { }
}

class Product
{
    public string Name
    {
        get => Name;
        set
        {
            if (Name != value)
                Name = value;
            else
                Console.WriteLine("Измените наименование продукта");
        }
    }
    public string? Description;
    public string? Price;
    public int lot;

    /* ... */
    
}

// Класс с набором инструментов для изменения информации заказа:
static class OrderEditing
{
    public static string NameCom { get { return "Интернет магазин точка ру"; } }
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
    public static void GenerateNumber(this ref int a)
    {
        a = GenerateNumber();
    }
    public static void GenerateNumber(this string a)
    {
        a = GenerateNumber().ToString();
    }
    public static void Sort(Product[] product)
    {
        for (int i = 0; i < product.Length; i++)
        {
            // 
        }
    }
    public static Product operator !(Product pr)
    {
        Console.WriteLine("Лот продукта: " + pr.lot);
        return pr;
    }
}