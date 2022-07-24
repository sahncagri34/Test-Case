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

    #region  Retrieve Data From Playfab
    
    public void PrepareDataFromPlayfab()
    {
        PlayFabManager.GetCatalogItemsPrices(OnDataReceivedSuccess,OnDataReceiveError);
    }
    private void OnDataReceivedSuccess(GetCatalogItemsResult result)
    {
        List<CatalogItem> catalogItems = result.Catalog;
        foreach (var item in catalogItems)
        {
            var retrievedData = (RetrieveData) JsonUtility.FromJson(item.CustomData,typeof(RetrieveData));
            DataPack.AddShopItem(retrievedData,item.DisplayName);
        }

        uiController.SpawnShopItems();
    }
    private void OnDataReceiveError(PlayFabError error)
    {
        throw new NotImplementedException();
    }

    #endregion
}
