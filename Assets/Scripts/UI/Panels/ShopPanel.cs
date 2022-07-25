using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : BasePanel 
{

    [SerializeField] ShopItem shopItemPrefab;
    [SerializeField] Transform shopItemsParent;
    [SerializeField] Text coinText;

    public override void Show()
    {
        base.Show();
        UpdateCoinText();
    }

    public void OnPlayButtonClicked()
    {
        GameManager.Instance.PushPanel(LobbyPanels.Game);
    }
    public void SpawnItems()
    {
        foreach (var item in DataPack.AllShopItems)
        {
            var shopItemInstance = Instantiate(shopItemPrefab,shopItemsParent);
            shopItemInstance.SetItem(item.ItemID,item.Identifier,item.Color,item.GearRatio,item.Weight,item.Price);
        }
    }
    public bool CheckIfItemPurchased(string itemID)
    {
        return DataPack.UserData.OwnedItems.FindIndex(x => x.ItemID == itemID) != -1;
    }
    public void ShopItem(string itemName, float itemPrice)
    {
        PlayFabManager.PurchaseItem(itemName, itemPrice,OnPurchaseSuccess, OnPurchaseError);
    }
    public void EquipItem(string itemID)
    {
        GameManager.Instance.ShowMessage($"Equipped : {itemID} !");
        DataPack.UserData.EquipItem(itemID);
    }
    void UpdateCoinText()
    {
        coinText.text = "Coin:" + DataPack.UserData.CurrencyAmount;
    }
    

    private void OnPurchaseSuccess(PurchaseItemResult obj)
    {
        foreach (var item in obj.Items)
        {
            DataPack.UserData.PurchaseItem(item.ItemId);
        }
        UpdateCoinText();
    }
    private void OnPurchaseError(PlayFabError obj)
    {
        GameManager.Instance.ShowMessage(obj.ErrorMessage);
    }

    
    
}