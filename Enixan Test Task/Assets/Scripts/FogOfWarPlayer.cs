using UnityEngine;
using System.Collections;

public class FogOfWarPlayer : MonoBehaviour
{

	public Transform FogOfWarPlane;
	public int Number = 1;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Ray rayToPlayerPos = Camera.main.ScreenPointToRay(transform.position);
		int layermask = 1 << 8;
		RaycastHit hit;
		if (Physics.Raycast(rayToPlayerPos, out hit, 1000, layermask))
		{
			FogOfWarPlane.GetComponent<Renderer>().material.SetVector("_Player" + Number.ToString() + "_Pos", hit.point);
		}
	}
}