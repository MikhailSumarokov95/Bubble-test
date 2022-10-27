using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCreatorLevel : CreatorLevels
{
    [SerializeField] private GameObject[] levels;

    [ContextMenu("CreateLevel")]
    public void CreateLevel(int number)
    {
        Destroy(levelOnScene);
        levelOnScene = Instantiate(levels[number - 1]);
        OnLevelCreated?.Invoke();
    }    
}
