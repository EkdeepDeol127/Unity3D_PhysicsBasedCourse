using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{

    public float velocity;
    public float jumpVelocity; 
    public Transform SpawnPositionPlayer;
    public bool onGround;
    public PlatformFall AccessPlatform1;
    public PlatformFall AccessPlatform2;
    public PlatformFall AccessPlatform3;

    private Rigidbody rb;
    private float gravity = 9.81f;
    private bool isPushing;
    private bool hasStoppedPushing;
    private const float RAYCASTLENGTH = 1.5f;


    // Use this for initialization
    void Start()
    {
        //resetPlayerLocation();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityChecker(); 
        onGroundChecker();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AccessPlatform1.ResetPlatform();
            AccessPlatform2.ResetPlatform();
            AccessPlatform3.ResetPlatform();
            resetPlayerLocation();
        }
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // JUMPING               
                this.rb.AddForce(new Vector3(0, jumpVelocity, this.rb.velocity.z * 0.05f), ForceMode.Impulse);
                Debug.Log("Jumping");
            }
            // ARROW KEY CONTROLS    
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                this.rb.AddForce(velocity * transform.right);
            }
            if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
            {
                this.rb.AddForce(velocity * transform.right * -1.0f);
            }
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                this.rb.AddForce(velocity * transform.forward);
            }
            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                this.rb.AddForce(velocity * transform.forward * -1.0f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

    }

    public void resetPlayerLocation()
    {
        rb.velocity = Vector3.zero;
        this.transform.position = SpawnPositionPlayer.position;
    }


    void onGroundChecker()
    {       
        Vector3 pointDirection = this.gameObject.transform.TransformDirection(Vector3.up * -1.0f) * 1.5f;
        Debug.DrawRay(transform.position, pointDirection, Color.magenta);

        if (Physics.Raycast(transform.position, pointDirection, RAYCASTLENGTH))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    void velocityChecker()
    {
        if (rb.velocity.z > 30.0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velocity); 
        }
    }
}
