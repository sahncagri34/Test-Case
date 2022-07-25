using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    private int currencyAmount;
    private int gatheredCoinAmountInGame;
    private int currentMeterInGame;
    private int highestMeterInGame;

    private ShopItemData equippedItem = new ShopItemData();
    private List<ShopItemData> ownedItems = new List<ShopItemData>();

    public List<ShopItemData> OwnedItems { get => ownedItems;}
    public ShopItemData EquippedItem { get => equippedItem;}

    public int CurrencyAmount { get => currencyAmount; }
    public int GatheredCoinAmountInGame { get => gatheredCoinAmountInGame;}
    public int CurrentMeterInGame { get => currentMeterInGame; }
    public int HighestMeterInGame { get => highestMeterInGame;}

    public void SetOwnedItem(string itemID, string identifier, string color, float gearRatio, float weight, float price)
    {
       var newOwnedItemData = new ShopItemData(itemID, identifier, color, gearRatio, weight, price);
        OwnedItems.Add(newOwnedItemData);
    }
    public void SetOwnedItem(ShopItemData ownedItemData)
    {
        if (ownedItems.Contains(ownedItemData)) return;

        ownedItems.Add(ownedItemData);
    }
    public void PurchaseItem(string itemID)
    {
        var ownedItem = DataPack.AllShopItems.Find(x => x.ItemID == itemID);
        SetOwnedItem(ownedItem);

        currencyAmount -= (int)ownedItem.Price;
    }

    public void EquipItem(string itemID)
    {
        var ownedItem = ownedItems.Find(x => x.ItemID == itemID);
        equippedItem = ownedItem;
        EventHandler.ItemEquipped?.Invoke();
    }


    public void SetCurrency(int currencyAmount)
    {
        this.currencyAmount = currencyAmount;
    }
    public void AddCoin()
    {
        gatheredCoinAmountInGame++;
    }
    public void UpdateMeter(int meter)
    {
        if(meter>CurrentMeterInGame)
        currentMeterInGame = meter;
    }
    
    public void SetHighestMeter(int meter)
    {
        highestMeterInGame = meter;
    }
}
