using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopup : BasePopup
{
    public void OnClickCloseButton()
    {
        PopupManager.ShowPopup<MainPopup>();
        Close();
    }

    protected override void OnClose()
    {
        PoolManager.Deactivate(this);
    }
}
