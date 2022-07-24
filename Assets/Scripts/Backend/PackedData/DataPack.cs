using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPack
{
    private static UserData userData;
    private static List<ShopItemData> allShopItems = new List<ShopItemData>();

    public static UserData UserData
    {
        get => userData;
    }
    public static List<ShopItemData> AllShopItems
    {
        get => allShopItems;
    }
    public static void AddShopItem(RetrieveData retrieveData,string itemIdentifier)
    {
        var newShopItemData = new ShopItemData
        (
        itemIdentifier
        ,retrieveData.color
        ,retrieveData.gearRatio
        ,retrieveData.weight
        ,retrieveData.price
        );

        allShopItems.Add(newShopItemData);
    }
}
