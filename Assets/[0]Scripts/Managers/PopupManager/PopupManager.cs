using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "UIManager", menuName = "Managers/UIManager")]
public class PopupManager : BaseInjectable, IAwake
{
    private Transform _uiParent;
    private PoolManager _poolManager;
    
    public void OnAwake()
    {
        _uiParent = GameObject.Find("UI").GetComponent<Transform>();
        _poolManager = InjectBox.Get<PoolManager>();
    }
    
    public T ShowPopup<T>(object obj = null) where T : BasePopup
    {
        var popup = _poolManager.GetPool(typeof(T))?.Activate<T>();

        if (popup == null)
        {
            var popupPrefab = Resources.Load<GameObject>("UI/Popups/" + typeof(T));
            var newPopup = _poolManager.Create<T>(popupPrefab, _uiParent);
            newPopup.Show(obj);
            return newPopup;
        }
        else
        {
            popup.Show(obj);
            return popup;
        }
    }
}
