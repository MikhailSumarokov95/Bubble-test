using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private float magnitudeForce;
    private GameObject _bubble;
    private BubbleCartridge _bubbleCartidge;

    private void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.05f, -Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (_bubble == null || _bubbleCartidge.IsMissed) CreateBubbles();
        if (Input.GetMouseButtonUp(0)) Fire();
    }

    private void CreateBubbles()
    {
        var numberBubble = Random.Range(0, bubbles.Length - 1);
        _bubble = Instantiate(bubbles[numberBubble], transform.position, Quaternion.identity);
        _bubbleCartidge = _bubble.GetComponent<BubbleCartridge>();
    }

    private void Fire()
    {
        var pressPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, - Camera.main.transform.position.z);
        var direction = (Camera.main.ScreenToWorldPoint(pressPoint) - transform.position).normalized;
        _bubble.GetComponent<Rigidbody>().AddForce(direction * magnitudeForce, ForceMode.Force);
    }
}
