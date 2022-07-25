using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] List<BasePanel> panels; 

    private Stack<BasePanel> panelStack;


    private void Start() => Initilize();

    private void Initilize()
    {
        panelStack = new Stack<BasePanel>();
        PushPanel(LobbyPanels.Login);
    }

    public BasePanel PushPanel(LobbyPanels panelType)
    {
        if(panelStack.Count > 0)
        {
            BasePanel currentPanel = panelStack.Peek();
            currentPanel.Hide();
        }

        BasePanel panelToPush = GetPanel(panelType);
        panelToPush.Show();

        panelStack.Push(panelToPush);

        return panelToPush;
    }
    public void PopPanel()
    {
        if(panelStack.Count <= 1) return;
        
        BasePanel panelToPop = panelStack.Pop();
        BasePanel currentPanel = panelStack.Peek();

        panelToPop.Hide();
        currentPanel.Show();
    }

    
    public BasePanel GetPanel(LobbyPanels panelType)
    {
        return panels[(int)panelType];
    }

    public void SpawnShopItems()
    {
        var shopPanel = (ShopPanel) GetPanel(LobbyPanels.Shop);

        shopPanel.SpawnItems();
    }
}

