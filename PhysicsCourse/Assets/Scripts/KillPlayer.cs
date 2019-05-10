using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public PlayerCntrl AccessPlayer;
    public PlatformFall AccessPlatform1;
    public PlatformFall AccessPlatform2;
    public PlatformFall AccessPlatform3;
    public PlatformFall AccessPlatform4;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AccessPlatform1.ResetPlatform();
            AccessPlatform2.ResetPlatform();
            AccessPlatform3.ResetPlatform();
            AccessPlatform4.ResetPlatform();
            AccessPlayer.resetPlayerLocation();
        }
    }
}
