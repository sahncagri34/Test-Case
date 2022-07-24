using UnityEngine;

public class GamePanel : BasePanel {
    public override void Show()
    {
        base.Show();
        EventHandler.GameStatusToggled.Invoke(true);
    }
}