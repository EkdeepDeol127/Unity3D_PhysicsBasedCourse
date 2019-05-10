using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour {

    public PlayerCntrl AccessPlayer;
    public Transform SpawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AccessPlayer.SpawnPositionPlayer.position = SpawnPoint.position;
        }
    }
}
