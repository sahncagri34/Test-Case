using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<BasePanel> panels; 

    private Stack<BasePanel> panelStack;


    private void Start() => Initilize();

    private void Initilize()
    {
        panelStack = new Stack<BasePanel>();
        PushPanel(LobbyPanels.Login);
    }

    public void PushPanel(LobbyPanels panelType)
    {
        if(panelStack.Count > 0)
        {
            BasePanel currentPanel = panelStack.Peek();
            currentPanel.Hide();
        }

        BasePanel panelToPush = GetPanel(panelType);
        panelToPush.Show();

        panelStack.Push(panelToPush);
    }
    public void PopPanel(LobbyPanels panelType)
    {
        if(panelStack.Count <= 2) return;
        
        BasePanel panelToPop = panelStack.Pop();
        BasePanel currentPanel = panelStack.Peek();

        currentPanel.Hide();
        currentPanel.Show();
    }

    
    BasePanel GetPanel(LobbyPanels panelType)
    {
        return panels[(int)panelType];
    }
}

