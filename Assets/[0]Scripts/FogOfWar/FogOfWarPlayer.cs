using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWarPlayer : MonoBehaviour
{
    public Transform FogOfWarPlane;
    public Transform Ground;
    public Transform Cube;
    public List<Transform> Transforms;

    private List<Vector4> _positions;
    private Renderer _planeRenderer;
    private Renderer _cubeRenderer;
    private Renderer _groundRenderer;

    private void Start()
    {
        _planeRenderer = FogOfWarPlane.GetComponent<Renderer>();
        _groundRenderer = Ground.GetComponent<Renderer>();
        _cubeRenderer = Cube.GetComponent<Renderer>();
    }

    private void Update()
    {
        _positions = ConvertTransformsToVector4(Transforms);
        
        _planeRenderer.material.SetInt("_ItemsCount", Transforms.Count);
        _planeRenderer.material.SetVectorArray("_ItemsPos", _positions);
        
        _groundRenderer.material.SetInt("_ItemsCount", Transforms.Count);
        _groundRenderer.material.SetVectorArray("_ItemsPos", _positions);
        
        _cubeRenderer.material.SetInt("_ItemsCount", Transforms.Count);
        _cubeRenderer.material.SetVectorArray("_ItemsPos", _positions);
    }

    private List<Vector4> ConvertTransformsToVector4 (List<Transform> transforms) 
    {
        var positions = new List<Vector4>();

        foreach (var transform in Transforms) 
        {
            var vector4 = new Vector4();

            vector4.x = transform.position.x;
            vector4.y = transform.position.y;
            vector4.z = transform.position.z;
            vector4.w = 1.0f;

            positions.Add(vector4);
        }

        return positions;
    }
}