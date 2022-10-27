using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCartridge : MonoBehaviour
{
    public bool IsMissed { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tag) OnHitted(other);
        else Missed();
    }

    private void Missed()
    {
        print("miss");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<SphereCollider>().isTrigger = true;
        gameObject.AddComponent<BubbleTarget>();
        IsMissed = true;
        Destroy(this);
    }

    private void OnHitted(Collider other)
    {
        print("hit");
        other.GetComponent<BubbleTarget>().Hit();
        Destroy(gameObject);
    }
}
