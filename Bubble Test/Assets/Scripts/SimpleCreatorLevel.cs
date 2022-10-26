using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCreatorLevel : CreatorLevels
{
    [SerializeField] private GameObject level;

    [ContextMenu("CreateLevel")]
    public void CreateLevel()
    {
        Destroy(levelOnScene);
        levelOnScene = Instantiate(level);
    }    
}
