using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentItemsController
{
    private List<ItemModel> _itemModels;
    private Transform _environmentParent;
    private int _randomSeed = 2;

    private GameManager _gameManager;
    private ItemData _itemData;
    private LevelData _levelData;
    private PoolManager _poolManager;
    
    public EnvironmentItemsController()
    {
        _gameManager = InjectBox.Get<GameManager>();
        _itemData = InjectBox.Get<ItemData>();
        _levelData = InjectBox.Get<LevelData>();
        _poolManager = InjectBox.Get<PoolManager>();

        _itemModels = _itemData.ItemModels;
        _environmentParent = GameObject.Find("Environment").GetComponent<Transform>();
    }

    public void BuildEnvironment()
    {
        var allPrefabs = _itemModels.Select(x => x.Prefab).ToList();
        var gridArea = DefineGridArea();

        var poolSize = (int)_levelData.GroundSize * (int)_levelData.GroundSize;
        
        for (int i = 0; i < _levelData.GroundSize; i++)
        {
            for (int j = 0; j < _levelData.GroundSize; j++)
            {
                var itemPrefab = allPrefabs[Random.Range(0, allPrefabs.Count)];
                var randomSeed = Random.Range(0, _randomSeed);

                if (randomSeed == 0)
                {
                    var item = _poolManager.Create<Item>(itemPrefab, _environmentParent, poolSize);
                    item.SetPosition(_levelData.GroundZeroPoint.x + i, _levelData.GroundZeroPoint.z + j);

                    foreach (var position in gridArea)
                    {
                        if (position == item.transform.position)
                        {
                            _poolManager.Deactivate(item);
                        }
                    }
                }
            }
        }
    }

    private List<Vector3> DefineGridArea()
    {
        var gridSize = _levelData.GetSize(_gameManager.CurrentLevel);
        var list = new List<Vector3>();

        var x = (2.0f - gridSize.HeightSize * 0.1f) *  5.0f;
        var z = (2.0f - gridSize.WidthSize * 0.1f) *  5.0f;
        
        for (var i = (int)x - 1 ; i < gridSize.HeightSize + ((int)x + 1); i++)
        {
            for (var j = (int)z - 1 ; j < gridSize.WidthSize + ((int)z + 1); j++)
            {
                var vector = new Vector3{x = i, z = j};
                list.Add(vector);
            }
        }

        return list;
    }
}
