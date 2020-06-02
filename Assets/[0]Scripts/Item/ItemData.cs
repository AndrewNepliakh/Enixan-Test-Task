﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemModel
{
    public eItemID ID;
    public eItemSize Size;
    public Sprite Icon;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemData : BaseInjectable
{
    public List<ItemModel> ItemModels;
}