using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : BasePanel 
{
    [SerializeField] private Text previousHihestScoreText;
    [SerializeField] private Text currentScoreText;
    public override void Show()
    {
        base.Show();

        previousHihestScoreText.text = " Last Highest Score: "+ DataPack.UserData.HighestMeterInGame.ToString();
        currentScoreText.text = "Current Score: " + DataPack.UserData.CurrentMeterInGame.ToString();

        EventHandler.GameStatusToggled?.Invoke(false);

        SendData();
    }

    void SendData()
    {

        PlayFabManager.AddCurrency(DataPack.UserData.GatheredCoinAmountInGame * 10, OnAddCurrencySuccess, OnAddCurrencyError);

        if (DataPack.UserData.HighestMeterInGame < DataPack.UserData.CurrentMeterInGame)
            PlayFabManager.AddPoint(DataPack.UserData.CurrentMeterInGame, OnAddPointSuccess, OnAddPointError);
    }
    
    private void OnAddCurrencySuccess(ModifyUserVirtualCurrencyResult obj)
    {
        DataPack.UserData.SetCurrency(obj.Balance);
    }

    private void OnAddCurrencyError(PlayFabError obj)
    {
        GameManager.Instance.ShowMessage(obj.ErrorMessage);
    }


    private void OnAddPointSuccess(UpdateUserDataResult obj)
    {

    }
    private void OnAddPointError(PlayFabError obj)
    {
        GameManager.Instance.ShowMessage(obj.ErrorMessage);
    }


}