using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPopup : BasePopup
{
    [SerializeField] private Button _gridButton;
    [SerializeField] private Button _shopButton;
    
    private GridController _gridController;
    
    private bool isGridActive = true;
    
    protected override void OnShow(object obj = null)
    {
        _gridController = InjectBox.Get<GameManager>().GetGridController();
    }

    public void OnClickGridButton()
    {
        isGridActive = !isGridActive;
        _gridController.SwitchGrid(isGridActive);
    }
    
    public void OnClickShopButton()
    {
        PopupManager.ShowPopup<ShopPopup>();
        
        Close();
    }

    protected override void OnClose()
    {
        PoolManager.Deactivate(this);
    }
    
}
