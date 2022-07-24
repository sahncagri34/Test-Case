using UnityEngine;

public class GamePanel : BasePanel {
    public override void Show()
    {
        base.Show();
        GameManager.Instance.GameStatusToggled.Invoke(true);
    }
}