using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreatorLevel : CreatorLevels
{
    [SerializeField] private CreatorLevels[] _creatorsLevels;
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private int countLines;
    [SerializeField] private int countColumns;
    [Range(0, 0.5f)]
    [SerializeField] private float yOffsetTopScreen; 
    [Range(0, 0.5f)]
    [SerializeField] private float xOffsetSideScreen;
    private float _yDistanceBetweenBubbles;
    private float _xDistanceBetweenBubbles;

    private void Start()
    {
        _yDistanceBetweenBubbles = 
            Camera.main.WorldToViewportPoint
            (new Vector3(0, bubbles[0].GetComponent<SphereCollider>().radius * 2f, 0)).y -
                Camera.main.WorldToViewportPoint(new Vector3(0, 0, 0)).y;

        _xDistanceBetweenBubbles = 
            Camera.main.WorldToViewportPoint
            (new Vector3(bubbles[0].GetComponent<SphereCollider>().radius * 2f, 0 , 0)).x -
                Camera.main.WorldToViewportPoint(new Vector3(0, 0, 0)).x;
    }

    [ContextMenu("CreateLevel")]
    public void CreateLevel()
    {
        foreach (var creatorlevels in _creatorsLevels) 
            if (creatorlevels.levelOnScene != null) Destroy(creatorlevels.levelOnScene);
        levelOnScene = new GameObject("level");
        for (int i = 0; i < countLines; i++)
        {
            var yPosition = yOffsetTopScreen + _yDistanceBetweenBubbles * i;
            for (int j = 0; j < countColumns; j++)
            {
                var xPosition = xOffsetSideScreen + _xDistanceBetweenBubbles * j;
                var position = Camera.main.ViewportToWorldPoint
                    (new Vector3(xPosition, 1 - yPosition, - Camera.main.transform.position.z));
                var numberBubbles = Random.Range(0, bubbles.Length - 1);
                Instantiate(bubbles[numberBubbles],
                    new Vector3(position.x, position.y, 0),
                    Quaternion.identity, levelOnScene.transform);
            }
        }
        CreateScreenBorders();
    }
}
