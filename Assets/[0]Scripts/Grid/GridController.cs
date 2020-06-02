using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController 
{
    private GameObject _cellPrefab;

    private List<Cell> _cells;
    private GridSize _gridSize;
    private LevelData _levelData;

    public GridController(LevelData levelData)
    {
        _gridSize = levelData.GetSize(0);
        _levelData = levelData;
    }

    public void BuildGrid()
    {
        for (int i = 0; i < _gridSize.HeightSize; i++)
        {
            for (int j = 0; j < _gridSize.WidthSize; j++)
            {
                
            }
        }
    }
}
