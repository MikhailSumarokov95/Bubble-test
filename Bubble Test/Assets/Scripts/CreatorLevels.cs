using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorLevels : MonoBehaviour
{
    private Camera _camera;
    private GameObject[] _borders;
    readonly float _widthBorders = 2f;
    protected GameObject levelOnScene;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _borders = new GameObject[4];
    }

    [ContextMenu("CreateScreenBorders")]
    public void CreateScreenBorders()
    {
        foreach (var border in _borders) Destroy(border);
        var leftTopPointScreen = _camera.ViewportToWorldPoint(new Vector3(1, 0, _camera.transform.position.z));
        var rightBotPointScreen = _camera.ViewportToWorldPoint(new Vector3(0, 1, _camera.transform.position.z));

        var leftBorders = new GameObject("LeftBorder");
        leftBorders.AddComponent<BoxCollider>();
        leftBorders.GetComponent<BoxCollider>().size = new Vector3(_widthBorders, Mathf.Abs(leftTopPointScreen.y) + Mathf.Abs(rightBotPointScreen.y), 0.1f);
        leftBorders.transform.position = new Vector3(leftTopPointScreen.x, rightBotPointScreen.y + (leftTopPointScreen.y - rightBotPointScreen.y) / 2);
        leftBorders.transform.rotation = Quaternion.Euler(0, 90, 0);
        _borders[0] = leftBorders;

        var rightBorders = new GameObject("RightBorder");
        rightBorders.AddComponent<BoxCollider>();
        rightBorders.GetComponent<BoxCollider>().size = new Vector3(_widthBorders, Mathf.Abs(leftTopPointScreen.y) + Mathf.Abs(rightBotPointScreen.y), 0.1f);
        rightBorders.transform.position = new Vector3(rightBotPointScreen.x, rightBotPointScreen.y + (leftTopPointScreen.y - rightBotPointScreen.y) / 2);
        rightBorders.transform.rotation = Quaternion.Euler(0, 90, 0);
        _borders[1] = rightBorders;

        var topBorders = new GameObject("TopBorder");
        topBorders.AddComponent<BoxCollider>();
        topBorders.GetComponent<BoxCollider>().size = new Vector3(Mathf.Abs(leftTopPointScreen.x) + Mathf.Abs(rightBotPointScreen.x), _widthBorders, 0.1f);
        topBorders.transform.position = new Vector3(rightBotPointScreen.x + (leftTopPointScreen.x - rightBotPointScreen.x) / 2, leftTopPointScreen.y);
        topBorders.transform.rotation = Quaternion.Euler(90, 0, 0);
        _borders[2] = topBorders;

        var botBorders = new GameObject("BotBorder");
        botBorders.AddComponent<BoxCollider>();
        botBorders.GetComponent<BoxCollider>().size = new Vector3(Mathf.Abs(leftTopPointScreen.x) + Mathf.Abs(rightBotPointScreen.x), _widthBorders, 0.1f);
        botBorders.transform.position = new Vector3(rightBotPointScreen.x + (leftTopPointScreen.x - rightBotPointScreen.x) / 2, rightBotPointScreen.y);
        botBorders.transform.rotation = Quaternion.Euler(90, 0, 0);
        _borders[3] = botBorders;

        foreach (var border in _borders) border.tag = "Border";
    }
}
