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

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        //if the groundcheckpoint object's (child of ball) has an object in the Ground layer within its radius, then 
        //ball is considered to have touched the ground
        isTouchingGround = Physics2D.OverlapCircle(groundcheckpoint.position, groundcheckradius, groundlayer);
        movement = Input.GetAxis("Horizontal");

        if (movement > 0f || movement < 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
        }
    }
}
