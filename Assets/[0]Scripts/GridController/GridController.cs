using System.Collections.Generic;
using UnityEngine;

public class GridController 
{
    private GameObject _cellPrefab;
    private Transform _gridParent;

    private GameManager _gameManager;
    private List<Cell> _cells;
    private GridSize _gridSize;
    private LevelData _levelData;
    private PoolManager _poolManager;

    public GridController()
    {
        _gameManager = InjectBox.Get<GameManager>();
        _levelData = InjectBox.Get<LevelData>();
        _poolManager = InjectBox.Get<PoolManager>();
        _cellPrefab = Resources.Load<GameObject>("Prefabs/Cell");
        _gridParent = GameObject.Find("Grid").GetComponent<Transform>();
        
        _cells = new List<Cell>();
        
        _gridSize = _levelData.GetSize(_gameManager.CurrentLevel);
    }

    public void BuildGrid()
    {
        
        for (int i = 0; i < _gridSize.HeightSize; i++)
        {
            for (int j = 0; j < _gridSize.WidthSize; j++)
            {
                var cell = _poolManager.Instantiate<Cell>(_cellPrefab);
                cell.SetPosition(i, j);
                cell.transform.SetParent(_gridParent);
                _cells.Add(cell);
            }
        }
        
        SetGridParentPosition();
    }

    private void SetGridParentPosition()
    {
        var position = new Vector3
        {
            x = (2.0f - _gridSize.HeightSize * 0.1f) * 5.0f, 
            z = (2.0f - _gridSize.WidthSize * 0.1f) * 5.0f
        };

        _gridParent.transform.position = position;
    }
}
