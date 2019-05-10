using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public bool bounceBack = false; 

	void Update ()
    {
        if (bounceBack == false)             
        {          
            this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.1f); 
            if (this.transform.position.z > 450.0f)
            {
                bounceBack = true;
            }
          
        }
        else if (bounceBack == true)
        {        
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.1f);
            if (this.transform.position.z < 400.0f)
            {
                bounceBack = false;
            }          
        }		
	}
}
