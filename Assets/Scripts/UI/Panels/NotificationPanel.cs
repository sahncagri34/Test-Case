using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : BasePanel
{
    [SerializeField] Text notificationText;


    public void ShowMessage(string text)
    {
        StartCoroutine(GetNotification(text));
    }
    private IEnumerator GetNotification(string text)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(2f);
        notificationText.text = "";
        
        GameManager.Instance.PopPanel();
    }

}
