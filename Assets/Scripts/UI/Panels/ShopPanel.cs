using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class ShopPanel : BasePanel {
    [SerializeField] ShopItem shopItemPrefab;
    [SerializeField] Transform shopItemsParent;

    
    public void SpawnItems()
    {
        foreach (var item in DataPack.AllShopItems)
        {
            var shopItemInstance = Instantiate(shopItemPrefab,shopItemsParent);
            shopItemInstance.SetItem(item.Identifier,item.Color,item.GearRatio,item.Weight,item.Price);
        }
    }

}