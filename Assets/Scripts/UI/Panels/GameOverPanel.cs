using UnityEngine;

public class GameOverPanel : BasePanel {
    public override void Show()
    {
        base.Show();
        EventHandler.GameStatusToggled.Invoke(false);
    }
}