using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCartridge : MonoBehaviour
{
    public bool IsMissed { get; private set; }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Border") return;
        if (collider.gameObject.tag == tag) OnHitted(collider);
        else Missed(collider);
    }

    private void Missed(Collision collider)
    {
        gameObject.AddComponent<BubbleTarget>();
        GetComponent<Rigidbody>().isKinematic = true;
        IsMissed = true;
        transform.parent = collider.transform.parent;
        Destroy(this);
    }

    private void OnHitted(Collision collider)
    {
        collider.gameObject.GetComponent<BubbleTarget>().Hit();
        Destroy(gameObject);
    }
}
