using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {

    private Rigidbody rb;
    public Transform StartPosition;

    void Start ()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }

    public void ResetPlatform()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        this.gameObject.transform.position = StartPosition.position;
    }
}
