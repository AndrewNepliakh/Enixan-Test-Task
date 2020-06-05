using Interfaces;
using UnityEngine;


[CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
public class GameManager : BaseInjectable, IAwake, IStart, IDisable
{
    private int _currentLevel = 0;
    
    private LevelData _levelData;
    private ItemData _itemData;
    private PopupManager _popupManager;

    private GridController _gridController;
    private EnvironmentItemsController _environmentItemsController;

    public int CurrentLevel => _currentLevel;


    public void OnAwake()
    {
        _itemData = InjectBox.Get<ItemData>();
        _levelData = InjectBox.Get<LevelData>();
        _popupManager = InjectBox.Get<PopupManager>();
        
        _gridController = new GridController();
        _environmentItemsController = new EnvironmentItemsController();
    }
    
    /// <summary>
    /// Start game
    /// </summary>
    public void OnStart()
    {
        _gridController.BuildGrid();
        _environmentItemsController.BuildEnvironment();
        _popupManager.ShowPopup<MainPopup>();
    }
    
    public GridController GetGridController()
    {
        return _gridController;
    }

    public void LocalDisable()
    {
       
    }
} 