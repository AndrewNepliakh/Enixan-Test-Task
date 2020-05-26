using UnityEngine;
using System.Collections;

public class FogOfWarPlayer : MonoBehaviour
{
    public Transform FogOfWarPlane;

    void Update()
    {
        FogOfWarPlane.GetComponent<Renderer>().material.SetVector("_PlayerPos", transform.position);
    }
}