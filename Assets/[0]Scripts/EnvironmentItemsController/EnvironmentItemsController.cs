using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentItemsController
{
    private List<ItemModel> _itemModels;
    private Transform _environmentParent;

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
        _environmentParent = GameObject.Find("GroundPlane").GetComponent<Transform>();
    }

    public void BuildEnvironment()
    {
        var allPrefabs = _itemModels.Select(x => x.Prefab).ToList();
        var gridArea = DefineGridArea();
        
        for (int i = 0; i < _levelData.GroundSize; i++)
        {
            for (int j = 0; j < _levelData.GroundSize; j++)
            {
                var itemPrefab = allPrefabs[Random.Range(0, allPrefabs.Count)];
                var item = _poolManager.Instantiate<Item>(itemPrefab);
                item.SetPosition(_levelData.GroundZeroPoint.x + i, _levelData.GroundZeroPoint.z + j);
                item.transform.SetParent(_environmentParent);

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

    private List<Vector3> DefineGridArea()
    {
        var gridSize = _levelData.GetSize(_gameManager.CurrentLevel);
        var list = new List<Vector3>();
        
        for (int i = 0; i < gridSize.HeightSize; i++)
        {
            for (int j = 0; j < gridSize.WidthSize; j++)
            {
                var vector = new Vector3{x = i, z = j};
                list.Add(vector);
            }
        }

        return list;
    }
}
