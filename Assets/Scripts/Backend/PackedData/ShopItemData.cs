public class ShopItemData
{
    private string itemID;
    private string identifier;
    private string color;
    private float gearRatio;
    private float weight;
    private float price;


    public string Identifier { get => identifier;}
    public string Color { get => color; }
    public float GearRatio { get => gearRatio; }
    public float Weight { get => weight; }
    public float Price { get => price; }
    public string ItemID { get => itemID; }

    public ShopItemData() { }
    
    public ShopItemData(string itemID,string identifier,string color, float gearRatio, float weight, float price)
    {
        this.itemID = itemID;
        this.identifier = identifier;
        this.color = color;
        this.gearRatio = gearRatio;
        this.weight = weight;
        this.price = price;
    }

}