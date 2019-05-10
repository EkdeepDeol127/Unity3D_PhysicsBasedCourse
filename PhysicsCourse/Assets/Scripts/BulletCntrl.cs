using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCntrl : MonoBehaviour {

    public GameObject playerTarget;

    private float VIY = 0;
    private float VFY;
    private float AY = -9.8f;
    private float DY = 0;
    private float T = 0;
    private float VIX = 0;
    private float VFX;
    private float AX = 0;
    private float DX = 0;
    private float angle = 0;
    private float speed = 0;
    private Vector3 direction = Vector3.zero;

    void Start ()
    {
        calculateLaunchVelocity();
        this.GetComponent<Rigidbody>().velocity = direction * speed;
        Destroy(this.gameObject, 2f);       
    }

    void calculateLaunchVelocity()
    {
        DX = Mathf.Abs(this.transform.position.z - playerTarget.transform.position.z) / 2;
        DY = Mathf.Abs((this.transform.position.y - playerTarget.transform.localScale.y));
        VIY = Mathf.Sqrt(Mathf.Abs((2 * AY * DY)));
        T = Mathf.Abs(DY / (0.5f * AY));
        VIX = (DX / T);
        speed = Mathf.Sqrt((Mathf.Pow(VIX, 2) + Mathf.Pow(VIY, 2)));
        angle = (Mathf.Atan2(VFY, VFX)) * (180 / Mathf.PI) * -1;
        //angle = -11f;
        direction = Quaternion.Euler(angle, 0, 0) * transform.forward;
        direction.Normalize();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerCntrl>().resetPlayerLocation(); 
        }
    }
}
