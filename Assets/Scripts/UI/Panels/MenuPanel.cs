using UnityEngine;

public class MenuPanel : BasePanel
{
    public void OnShopButtonClicked()
    {
        GameManager.Instance.PushPanel(LobbyPanels.Shop);
    }
    public void OnPlayButtonClicked()
    {
        GameManager.Instance.PushPanel(LobbyPanels.Game);
    }
    
}