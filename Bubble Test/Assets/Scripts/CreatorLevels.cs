using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorLevels : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private GameObject[] _borders;
    readonly float _widthBorders = 2f;
    protected GameObject levelOnScene;

    [ContextMenu("CreateScreenBorders")]
    protected void CreateScreenBorders()
    {
        if (_borders != null) return;
        _borders = new GameObject[4];
        var leftTopPointScreen = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.transform.position.z));
        var rightBotPointScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.transform.position.z));

        var sizeSideBorder = new Vector3(_widthBorders, Mathf.Abs(leftTopPointScreen.y) + Mathf.Abs(rightBotPointScreen.y), 0.1f);

        _borders[0] = new GameObject("LeftBorder");
        var leftBordersCollider = _borders[0].AddComponent<BoxCollider>();
        leftBordersCollider.size = sizeSideBorder;
        _borders[0].transform.position = new Vector3(leftTopPointScreen.x, rightBotPointScreen.y + (leftTopPointScreen.y - rightBotPointScreen.y) / 2);
        _borders[0].transform.rotation = Quaternion.Euler(0, 90, 0);


        _borders[1] = new GameObject("RightBorder");
        var rightBordersCollider = _borders[1].AddComponent<BoxCollider>();
        rightBordersCollider.size = sizeSideBorder;
        _borders[1].transform.position = new Vector3(rightBotPointScreen.x, rightBotPointScreen.y + (leftTopPointScreen.y - rightBotPointScreen.y) / 2);
        _borders[1].transform.rotation = Quaternion.Euler(0, 90, 0);

        var sizeTopAndBotBorder = new Vector3(Mathf.Abs(leftTopPointScreen.x) + Mathf.Abs(rightBotPointScreen.x), _widthBorders, 0.1f);

        _borders[2] = new GameObject("TopBorder");
        var topBordersCollider = _borders[2].AddComponent<BoxCollider>();
        topBordersCollider.size = sizeTopAndBotBorder;
        _borders[2].transform.position = new Vector3(rightBotPointScreen.x + (leftTopPointScreen.x - rightBotPointScreen.x) / 2, leftTopPointScreen.y);
        _borders[2].transform.rotation = Quaternion.Euler(90, 0, 0);

        _borders[3] = new GameObject("BotBorder");
        var botBordersCollider = _borders[3].AddComponent<BoxCollider>();
        botBordersCollider.size = sizeTopAndBotBorder;
        _borders[3].transform.position = new Vector3(rightBotPointScreen.x + (leftTopPointScreen.x - rightBotPointScreen.x) / 2, rightBotPointScreen.y);
        _borders[3].transform.rotation = Quaternion.Euler(90, 0, 0);

        foreach (var border in _borders) border.tag = "Border";
    }
}
