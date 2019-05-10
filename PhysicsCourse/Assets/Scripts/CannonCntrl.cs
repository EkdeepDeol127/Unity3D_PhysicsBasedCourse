using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCntrl : MonoBehaviour {

    public GameObject bullet;
    public Transform BulletSpawn;
    public GameObject playerTarget;
    private float timerMax = 2f;
    private float timerMin = 0f;
    private bool playerInSight = false;
    private float turnspeed = 10;
    private float step;

    void Update()
    {
        if (playerInSight)
        {
            timerMax -= Time.deltaTime;
            if (timerMax < timerMin)
            {
                createProjectile();
                timerMax = 2f;
            }
        }
        lookAt();
    }
      
   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInSight = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInSight = false;
        }
    }

    void lookAt()
    {
        Vector3 targetDir = playerTarget.transform.position - transform.position;
        step = turnspeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void createProjectile()
    {
        Instantiate(bullet, BulletSpawn);      
    }
}
