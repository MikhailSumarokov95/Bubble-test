using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCreatorLevel : CreatorLevels
{
    [SerializeField] private GameObject[] levels;
    [SerializeField] private CreatorLevels[] _creatorsLevels;

    [ContextMenu("CreateLevel")]
    public void CreateLevel(int number)
    {
        foreach (var creatorlevels in _creatorsLevels) 
            if (creatorlevels.levelOnScene != null) Destroy(creatorlevels.levelOnScene);
        levelOnScene = Instantiate(levels[number - 1]);
        CreateScreenBorders();
    }    
}
