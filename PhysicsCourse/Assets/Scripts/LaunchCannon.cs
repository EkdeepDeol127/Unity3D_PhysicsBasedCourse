using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannon : MonoBehaviour {

    public GameObject player;
    public GameObject target;
    public GameObject wall;
    public Transform EndBarrel;

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
    private bool once = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.position = EndBarrel.position;
            calculateLaunchVelocity();
            doLaunchPlayer();
        }
    }
    
    void doLaunchPlayer()
    {
        if(once == false)
        {
            //once = true;
            if (Mathf.Abs(player.GetComponent<Rigidbody>().velocity.sqrMagnitude) < 0.00001f)
            {
                player.GetComponent<Rigidbody>().velocity = direction * speed;
            }
            Debug.Log("DX: " + DX);
            Debug.Log("DY: " + DY);
            Debug.Log("Time: " + T);
            Debug.Log("VIY: " + VIY);
            Debug.Log("VIX: " + VIX);
            Debug.Log("Angle: " + angle);
            Debug.Log("Speed: " + speed);
        }
    }

    void calculateLaunchVelocity()
    {
        DX = Mathf.Abs(player.transform.position.z - target.transform.position.z) / 2;
        DY = Mathf.Abs((player.transform.position.y - wall.transform.localScale.y) * 2);
        VIY = Mathf.Sqrt(Mathf.Abs((2 * AY * DY)));
        T = Mathf.Abs(VIY / AY);
        VIX = (DX / T);
        speed = Mathf.Sqrt((Mathf.Pow(VIX, 2) + Mathf.Pow(VIY, 2)));
        angle = (Mathf.Abs((Mathf.Atan2(VFY, VFX)) * (180 / Mathf.PI))) * -1;
        angle = -11f;
        direction = Quaternion.Euler(angle, 0, 0) * transform.forward;
        direction.Normalize();
    }
}