using Interfaces;
using UnityEngine;


[CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
public class GameManager : BaseInjectable, IAwake, IStart, IDisable
{
    private int _currentLevel = 0;
    
    private LevelData _levelData;
    private ItemData _itemData;

    private GridController _gridController;
    private EnvironmentItemsController _environmentItemsController;

    public int CurrentLevel => _currentLevel;


    public void OnAwake()
    {
        _itemData = InjectBox.Get<ItemData>();
        _levelData = InjectBox.Get<LevelData>();
        
        _gridController = new GridController();
        _environmentItemsController = new EnvironmentItemsController();
    }
    
    public void OnStart()
    {
        BuildEnvironmentItemsSet();
    }

    public void LocalDisable()
    {
       
    }

    private void BuildEnvironmentItemsSet()
    {
        _gridController.BuildGrid();
        _environmentItemsController.BuildEnvironment();
    }
} 