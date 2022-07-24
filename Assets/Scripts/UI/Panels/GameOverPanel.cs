using UnityEngine;

public class GameOverPanel : BasePanel {
    public override void Show()
    {
        base.Show();
        GameManager.Instance.GameStatusToggled.Invoke(false);
    }
}