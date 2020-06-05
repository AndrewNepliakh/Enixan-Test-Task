using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour, IPoolable
{
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
