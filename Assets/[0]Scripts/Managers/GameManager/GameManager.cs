using UnityEngine;


[CreateAssetMenu(menuName = "GameManager", fileName = "GameManager")]
public class GameManager : BaseInjectable, IStart, IDisable
{

    private LevelData _levelData;
    private ItemData _itemData;
    
    public void OnStart()
    {
        _itemData = InjectBox.Get<ItemData>();
        _levelData = InjectBox.Get<LevelData>();
    }

    public void LocalDisable()
    {
       
    }

    private void BuildEnvironmentItemsSet()
    {
        
    }
}