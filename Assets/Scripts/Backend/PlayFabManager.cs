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
}
