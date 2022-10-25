using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreatorLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private int countLines;
    [SerializeField] private int countColumns;
    [SerializeField] private float distanceBetweenBubbles;
    [SerializeField] private float yStartingPosition;

    [ContextMenu("CreateLevel")]
    public void CreateLevel()
    {
        var yPosition = yStartingPosition;
        for (int i = 0; i < countLines; i++)
        {
            yPosition -= distanceBetweenBubbles;
            for (int j = 0; j < countColumns; j++)
            {
                var numberBubbles = Random.Range(0, bubbles.Length - 1);
                Instantiate(bubbles[numberBubbles],
                    new Vector3(j * distanceBetweenBubbles, yPosition * distanceBetweenBubbles, 0),
                    Quaternion.identity);
            }
        }
    }
}
