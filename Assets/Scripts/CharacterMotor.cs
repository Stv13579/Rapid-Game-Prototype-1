using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public Rigidbody2D RB2D;
    private float MovementSpeed = 10.0f;
    private Vector2 Velo;
    private bool Grounded = true;
    private float JumpHeight = 5000.0f;
    private bool Chain = false;

    // Update is called once per frame
    void Update()
    {
        // movement on the horizontal axis
        Velo.x = Input.GetAxis("Horizontal") * MovementSpeed;

        // flipping the sprite
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0) // spirte looking at the left side
        {
            characterScale.x = -10;
        }
        if (Input.GetAxis("Horizontal") > 0) // spirte looking at the right side
        {
            characterScale.x = 10;
        }
        transform.localScale = characterScale;


        if(Chain == true) // if player is in chain then it can climb up
        {
            Velo.y = Input.GetAxis("Vertical") * MovementSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            RB2D.velocity = Vector2.up * JumpHeight;
            Grounded = false;
        }
    }

    void FixedUpdate()
    {
        RB2D.velocity = new Vector2 (Velo.x,Velo.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chain")
        {
            Chain = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Chain")
        {
            Chain = false;
        }
    }
}
