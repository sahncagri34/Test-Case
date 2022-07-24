using UnityEngine;

public class MenuPanel : BasePanel
{
    public override void Show()
    {
        base.Show();
        GameManager.Instance.PrepareDataFromPlayfab();
    }
    public void OnShopButtonClicked()
    {
        GameManager.Instance.PushPanel(LobbyPanels.Shop);
    }
    public void OnPlayButtonClicked()
    {
        GameManager.Instance.PushPanel(LobbyPanels.Game);
    }
    
}