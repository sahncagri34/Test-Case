using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    private int currencyAmount;
    private List<ShopItemData> shopItems;

    public UserData(int currencyAmount, List<ShopItemData> shopItems)
    {
        this.currencyAmount = currencyAmount;
        this.shopItems = shopItems;
    }
}
