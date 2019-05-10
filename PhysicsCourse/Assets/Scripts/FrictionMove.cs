using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionMove : MonoBehaviour {


    private float boxStaticFriction;
    private float boxDynamicFriction;
    private float boxGravityForce;
    private float boxOvercomeForce;
    private float totalPushingForce; 

    private float PlayerForce; 
    private float gravity = 9.8f; 

	void Start ()
    {
        boxStaticFriction = this.GetComponent<BoxCollider>().material.staticFriction;
        boxDynamicFriction = this.GetComponent<BoxCollider>().material.dynamicFriction; 
	}
	
	
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doPushingCheck(other.gameObject); 
        }
    }

    void doPushingCheck(GameObject thePlayer)
    {
        boxGravityForce = this.GetComponent<Rigidbody>().mass * gravity;
        boxOvercomeForce = boxGravityForce * boxStaticFriction;

        PlayerForce = thePlayer.GetComponent<Rigidbody>().mass * thePlayer.GetComponent<Rigidbody>().velocity.magnitude; 

        if(PlayerForce > boxOvercomeForce)
        {
            totalPushingForce = boxOvercomeForce - PlayerForce;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(this.transform.position.x, this.transform.position.y, totalPushingForce));
            Debug.Log("Player is pushing Box..."); 

        }
        else
        {
            Debug.Log("Not enough force..."); 
        }

    }
}
