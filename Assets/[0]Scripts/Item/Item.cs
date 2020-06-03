using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoEntity, IPoolable
{
   [SerializeField] private eItemID _id;

   public eItemID ID => _id;
   
   public void SetPosition(float x, float z)
   {
      var position = new Vector3 {x = x, z = z};
      transform.position = position;
   }
   public void OnActivate(object argument = default)
   {
      gameObject.SetActive(true);
   }

   public void OnDeactivate(object argument = default)
   {
      gameObject.SetActive(false);
   }
}
