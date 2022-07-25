using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [Header("REFERENCES")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private SticksController sticksController;
    [SerializeField] private UIController uiController;

   
    private void Awake() => Initialize();


    private void Initialize()
    {
        _instance = this;
    }

    public Vector3 GetCameraScreenToWorldPoint(Vector3 point)
    {
        return cameraController.GetCameraScreenToWorldPoint(point);
    }
    public float GetStickCurrentSpeed()
    {
        return sticksController.GetCurrentSpeed();
    }
    public BasePanel GetPanel(LobbyPanels panelType)
    {
        return uiController.GetPanel(panelType);
    }
     public void PushPanel(LobbyPanels panelType)
    {
        uiController.PushPanel(panelType);
    }

    public void PopPanel()
    {
        uiController.PopPanel();
    }

    public void ShowMessage(string text)
    {
        var notificationPanel = (NotificationPanel) uiController.PushPanel(LobbyPanels.Notification);
        notificationPanel.ShowMessage(text);
    }

    public void UpdateMeter(float meter)
    {
        DataPack.UserData.UpdateMeter((int)meter);
        var gamePanel = (GamePanel)GetPanel(LobbyPanels.Game);
        gamePanel.UpdateMeterText(meter);
    }

    #region  Retrieve Data From Playfab

    public void PrepareDataFromPlayfab()
    {
        PlayFabManager.GetCatalogItemsPrices(OnCatalogDataReceivedSuccess,OnCatalogDataReceiveError);
    }

    private void OnCatalogDataReceivedSuccess(GetCatalogItemsResult result)
    {
        List<CatalogItem> catalogItems = result.Catalog;
        foreach (var item in catalogItems)
        {
            var retrievedData = (RetrieveData) JsonUtility.FromJson(item.CustomData,typeof(RetrieveData));
            DataPack.AddShopItem(retrievedData,item.DisplayName,item.ItemId);
        }

        uiController.SpawnShopItems();

        PlayFabManager.GetUserInventory(OnUserInventoryDataReceivedSuccess, OnUserInventoryDataReceivedError);
    }

    private void OnCatalogDataReceiveError(PlayFabError error)
    {
        ShowMessage(error.ErrorMessage);
    }

    private void OnUserInventoryDataReceivedSuccess(GetUserInventoryResult result)
    {
        UserData userData = new UserData();
        DataPack.UserData = userData;
        DataPack.UserData.SetCurrency(result.VirtualCurrency["GC"]);

        foreach (var item in result.Inventory)
        {
            var itemID = item.ItemId;
            
            var ownedItem = DataPack.AllShopItems.Find(x=> x.ItemID == itemID);
            if (ownedItem == null) continue;

            DataPack.UserData.SetOwnedItem(ownedItem);
        }

        PushPanel(LobbyPanels.Menu);

        PlayFabManager.GetUserData(OnUserDataReceivedSuccess, OnUserDataReceivedError);
    }

    private void OnUserInventoryDataReceivedError(PlayFabError error)
    {
        ShowMessage(error.ErrorMessage);
    }

    private void OnUserDataReceivedSuccess(GetUserDataResult obj)
    {
        if (!obj.Data.ContainsKey("point")) return;

        var meter = Convert.ToInt32(obj.Data["point"].Value);
        DataPack.UserData.SetHighestMeter(meter);
    }

    private void OnUserDataReceivedError(PlayFabError error)
    {
        ShowMessage(error.ErrorMessage);
    }


    #endregion


}
