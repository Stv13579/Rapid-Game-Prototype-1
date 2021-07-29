using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public Rigidbody2D RB2D;
    private float MovementSpeed = 10.0f;

    // variables for jumping
    public Transform GroundedBox;
    public float Grounded = 0.0f;
    public float GroundedLenience = 0.25f;
    public LayerMask GroundLayerMask;
    public float JumpHeight = 5.0f;

    // chains
    private bool Chain = false;

    // movement
    private Vector2 input;
    private Vector2 Velocity;
    public float acceleration = 4.0f;
    public AnimationCurve frictioncurve = AnimationCurve.Linear(0.0f, 0.1f, 1.0f, 1.0f);
    public float stopmodifier = 2.0f;
    public float airmodifier = 0.5f;
    public float turnmodifier = 2.0f;

    private void OnDrawGizmos()
    {
        Vector3[] Points = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, 0.0f),
            new Vector3(0.5f, -0.5f, 0.0f),
            new Vector3(0.5f, 0.5f, 0.0f),
            new Vector3(-0.5f, 0.5f, 0.0f)
        };

        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].x *= GroundedBox.lossyScale.x;
            Points[i].y *= GroundedBox.lossyScale.y;
            Points[i] += GroundedBox.position;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Points[0], Points[1]);
        Gizmos.DrawLine(Points[1], Points[2]);
        Gizmos.DrawLine(Points[2], Points[3]);
        Gizmos.DrawLine(Points[3], Points[0]);
    }

    // Update is called once per frame
    void Update()
    {
        // movement on the horizontal axis
        input.x = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            input.y = 1.0f;
        }
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


        //if(Chain == true) // if player is in chain then it can climb up
        //{
        //     = Input.GetAxis("Vertical") * MovementSpeed;
        //}

    }
    public bool Approx(float a, float b)
    {
        return (Mathf.Abs(a - b) < 0.01f);
    }
    void FixedUpdate()
    {
        float CacheX = Velocity.x; // 1
        float airMod = (Grounded > GroundedLenience - 0.01) ? 1.0f : airmodifier; //
        float turnMod = Approx(Mathf.Sign(CacheX), input.x) ? 1.0f : turnmodifier; //
        float stopMod = Approx(input.x, 0.0f) ? stopmodifier : 1.0f;
        float accelerationStep = acceleration * Time.fixedDeltaTime * airMod;
        Velocity.x += input.x * accelerationStep * turnMod; // += 1 * 4 * X
        Velocity.x -= Mathf.Sign(Velocity.x) * accelerationStep * frictioncurve.Evaluate(Mathf.Abs(CacheX)) * stopMod; // -= 1 * 4 * friction * X
        if (Mathf.Abs(input.x) < 0.01f && Mathf.Abs(Mathf.Sign(CacheX) - Mathf.Sign(Velocity.x)) > 0.01f)
        {
            Velocity.x = 0.0f;
        }

        Grounded -= Time.fixedDeltaTime;
        Collider2D GroundHit = Physics2D.OverlapBox(GroundedBox.position, GroundedBox.lossyScale, 0.0f, GroundLayerMask);
        if (GroundHit)
        {
            Grounded = GroundedLenience;
        }

        if (input.y > 0.0f)
        {
            if (Grounded > 0.0f)
            {
                Vector2 velocity = RB2D.velocity;
                velocity.y = JumpHeight;
                RB2D.velocity = velocity;
                Grounded = 0.0f;
            }
            input.y = 0.0f;
        }

        RB2D.velocity = new Vector2 (Velocity.x * MovementSpeed, RB2D.velocity.y);
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
            Velocity.y = 0.0f;
        }
    }
}
