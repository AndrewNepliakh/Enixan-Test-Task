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

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData/LevelData")]
public class LevelData : BaseInjectable
{
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