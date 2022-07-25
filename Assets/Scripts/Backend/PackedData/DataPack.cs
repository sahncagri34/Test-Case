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
        set => userData = value;
    }
    public static List<ShopItemData> AllShopItems
    {
        get => allShopItems;
    }
    public static void AddShopItem(RetrieveData retrieveData, string itemIdentifier, string itemID)
    {
        var newShopItemData = new ShopItemData
        (
         itemID
        ,itemIdentifier
        , retrieveData.color
        , retrieveData.gearRatio
        , retrieveData.weight
        , retrieveData.price
        );

        allShopItems.Add(newShopItemData);
    }
}
