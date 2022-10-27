using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private float magnitudeForce;
    private GameObject _bubble;

    private void Update()
    {
        if (_bubble == null) CreateBubbles();
        if (Input.GetMouseButtonUp(0)) Fire();
    }

    private void Fire()
    {
        var pressPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
        var direction = (transform.position - Camera.main.ScreenToWorldPoint(pressPoint)).normalized;
        _bubble.GetComponent<Rigidbody>().AddForce(direction * magnitudeForce, ForceMode.Force);
    }

    private void CreateBubbles()
    {
        var numberBubble = Random.Range(0, bubbles.Length - 1);
        _bubble = Instantiate(bubbles[numberBubble], transform.position, Quaternion.identity);
    }
}
