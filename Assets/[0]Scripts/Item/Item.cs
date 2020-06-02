using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoEntity
{
   [SerializeField] private eItemID _id;

   public eItemID ID => _id;
}
