using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel 
{
    [SerializeField] private Text meterText;

   
    public override void Show()
    {
        base.Show();
        EventHandler.GameStatusToggled?.Invoke(true);
    }
    public void UpdateMeterText(float meter)
    {
        meterText.text = ((int)meter).ToString();
    }

   

}