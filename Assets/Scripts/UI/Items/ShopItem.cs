using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Image shopItemImage;
    [SerializeField] Text shopItemIdentifierText;
    [SerializeField] Text shopItemPriceText;
    private float price;
    private string itemId;

    public void SetItem(string itemID,string identifier,string color, float gearRatio, float weight, float price)
    {
        this.shopItemIdentifierText.text = identifier;
        this.shopItemImage.color = color.ToColor();
        this.shopItemPriceText.text = price.ToString();

        this.itemId = itemID;
        this.price = price;
    }

    public void OnShopButtonClicked()
    {
        var shopPanel = (ShopPanel)GameManager.Instance.GetPanel(LobbyPanels.Shop);

        var isPurchased = shopPanel.CheckIfItemPurchased(itemId);

        if (isPurchased)
        {
            shopPanel.EquipItem(itemId);
        }
        else
        {
            shopPanel.ShopItem(itemId, price);
        }
        
    }
}
