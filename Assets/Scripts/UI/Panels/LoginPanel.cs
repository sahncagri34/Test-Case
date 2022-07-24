using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class LoginPanel : BasePanel
{

    public void OnLoginButtonClicked() => Login();

    void Login()
    {
        PlayFabManager.Login(OnLoginSuccess,OnLoginError);
    }
    private void OnLoginSuccess(LoginResult obj)
    {
        GameManager.Instance.PushPanel(LobbyPanels.Menu);
    }
    private void OnLoginError(PlayFabError obj)
    {
        GameManager.Instance.ShowMessage(obj.ErrorMessage);
    }


}