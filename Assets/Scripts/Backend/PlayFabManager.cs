using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public static class PlayFabManager
{
    public static void Login(Action<LoginResult> OnSuccess,Action<PlayFabError> OnError)
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public static void GetCatalogItemsPrices(Action<GetCatalogItemsResult> OnSuccess,Action<PlayFabError> OnError)
    {
        var request = new GetCatalogItemsRequest();
        request.CatalogVersion = "Balls";

        PlayFabClientAPI.GetCatalogItems(request,OnSuccess,OnError);
    }

    public static void PurchaseItem(string shopItemID, float shopItemPrice, Action<PurchaseItemResult> OnSuccess, Action<PlayFabError> OnError)
    {
        PurchaseItemRequest request = new PurchaseItemRequest();

        request.CatalogVersion = "Balls";
        request.VirtualCurrency = "GC";
        request.ItemId = shopItemID;
        request.Price = (int)shopItemPrice;

        PlayFabClientAPI.PurchaseItem(request, OnSuccess, OnError);
        
    }
    public static void GetUserInventory(Action<GetUserInventoryResult> OnSuccess, Action<PlayFabError> OnError)
    {
        GetUserInventoryRequest request = new GetUserInventoryRequest();

        PlayFabClientAPI.GetUserInventory(request,OnSuccess,OnError);
    }
    public static void AddCurrency(int amountOfCoin, Action<ModifyUserVirtualCurrencyResult> OnSuccess, Action<PlayFabError> OnError)
    {
        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest();
        request.Amount = amountOfCoin;
        request.VirtualCurrency = "GC";

        PlayFabClientAPI.AddUserVirtualCurrency(request,OnSuccess,OnError);
    }
    public static void AddPoint(int amountOfPoint, Action<UpdateUserDataResult> OnSuccess, Action<PlayFabError> OnError)
    {
        UpdateUserDataRequest userDataRequest = new UpdateUserDataRequest();
        userDataRequest.Data = new Dictionary<string, string>()
        {
            {"point", amountOfPoint.ToString()},
        };
        PlayFabClientAPI.UpdateUserData(userDataRequest,OnSuccess,OnError);
    }
    public static void GetUserData(Action<GetUserDataResult> OnSuccess, Action<PlayFabError> OnError)
    {
        GetUserDataRequest request = new GetUserDataRequest();
        request.Keys = new List<string>()
        {
            "point"
        };
        PlayFabClientAPI.GetUserData(request,OnSuccess,OnError);
    }
}
