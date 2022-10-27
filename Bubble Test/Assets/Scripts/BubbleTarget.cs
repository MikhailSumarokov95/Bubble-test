using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTarget : MonoBehaviour
{
    private bool _isDestroy;

    public void Hit()
    {
        if (_isDestroy) return;
        _isDestroy = true;
        Destroy(gameObject);
        for (int i = 0; i < 360; i += 30)
        {
            var ray = new Ray(transform.position, new Vector3(Mathf.Sin(i * Mathf.Deg2Rad), Mathf.Cos(i * Mathf.Deg2Rad)));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == tag)
                    hit.collider.GetComponent<BubbleTarget>()?.Hit();
            }
        }
    }
}
