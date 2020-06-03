using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    public int HeightSize;
    public int WidthSize;
}

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelData : BaseInjectable
{
    private const float _groundSize = 50.0f;
    private static readonly Vector3 _groundZeroPoint = new Vector3(-15.0f, 0.0f, -15.0f);

    public float GroundSize => _groundSize;
    public Vector3 GroundZeroPoint => _groundZeroPoint;

    public List<Level> Levels;

    public GridSize GetSize(int level)
    {
        return new GridSize()
        {
            HeightSize = Levels[level].HeightSize,
            WidthSize =  Levels[level].WidthSize
        };
    }
}