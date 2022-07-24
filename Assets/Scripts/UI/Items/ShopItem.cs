using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Image shopItemImage;
    [SerializeField] Text shopItemIdentifierText;
    [SerializeField] Text shopItemPriceText;

    public void SetItem(string identifier,string color, float gearRatio, float weight, float price)
    {
        this.shopItemIdentifierText.text = identifier;
        this.shopItemImage.color = color.ToColor();
        this.shopItemPriceText.text = price.ToString();
    }

    public void OnShopButtonClicked()
    {
        //TODO SHOP => PLAYFAB

    }
}
