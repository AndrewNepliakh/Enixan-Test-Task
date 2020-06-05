using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour, IPoolable
{
    public eItemID ID { get; set; }

    [SerializeField] private Text _itemIDText; 
    [SerializeField] private Image _itemIcon; 
    [SerializeField] private Button _selectButton;
    private GameObject _itemPrefab;

    private ItemData _itemData; 

    public void InitItemView(eItemID id, ItemData itemData)
    {
        ID = id;
        _itemData = itemData;

        _itemIDText.text = ID.ToString();
        _itemIcon.sprite = itemData.GetItemIcon(id);
        _itemPrefab = itemData.GetItemPrefab(id);
    }

    public void OnClickSelectButton()
    {
        
    }

    public void OnActivate(object argument = default)
    {
        
    }

    public void OnDeactivate(object argument = default)
    {
        
    }
}
