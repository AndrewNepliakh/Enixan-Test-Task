using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemModel
{
    public eItemID ID;
    public eItemSize Size;
    public Sprite Icon;
    public GameObject Prefab;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : BaseInjectable
{
    public List<ItemModel> ItemModels;

    public Sprite GetItemIcon(eItemID id)
    {
        return ItemModels.Find(x => x.ID == id).Icon;
    }

    public GameObject GetItemPrefab(eItemID id)
    {
        return ItemModels.Find(x => x.ID == id).Prefab;
    }
}