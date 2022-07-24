public class ShopItemData
{
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

    public ShopItemData(string identifier,string color, float gearRatio, float weight, float price)
    {
        this.identifier = identifier;
        this.color = color;
        this.gearRatio = gearRatio;
        this.weight = weight;
        this.price = price;
    }

}