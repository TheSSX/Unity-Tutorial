using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlla : MonoBehaviour {

    private float speed = 5;
    public float jumpspeed = 7f;
    private float movement = 0f;
    private Rigidbody2D rigidbody;
    public Transform groundcheckpoint;
    public float groundcheckradius;
    public LayerMask groundlayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawnpoint;
    public LevelManager gamelevelmanager;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnpoint = transform.position;
        gamelevelmanager = GameObject.FindObjectOfType<LevelManager>(); //FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the groundcheckpoint object's (child of ball) has an object in the Ground layer within its radius, then 
        //ball is considered to have touched the ground
        isTouchingGround = Physics2D.OverlapCircle(groundcheckpoint.position, groundcheckradius, groundlayer);
        movement = Input.GetAxis("Horizontal");

        if (movement > 0f) 
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(0.8f, 0.8f);    //make Mario point to the right
        }
        else if (movement < 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-0.8f, 0.8f);   //make Mario point to the left
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
        }

        //Animation code, changes the parameters in the Animator object
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            gamelevelmanager.respawn();  
        }

        if (other.tag == "Checkpoint")
        {
            respawnpoint = other.transform.position;
        }
    }
}
