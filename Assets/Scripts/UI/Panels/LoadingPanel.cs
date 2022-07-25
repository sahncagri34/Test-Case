using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : BasePanel
{
    [SerializeField] private Animator loadingAnim;

    public override void Show()
    {
        base.Show();
        loadingAnim.enabled = true;
    }
    public override void Hide()
    {
        loadingAnim.enabled = false;
        base.Hide();
    }

}
