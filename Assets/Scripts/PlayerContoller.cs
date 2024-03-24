using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float fallSpeed;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode down;
    public KeyCode shoot;

    private Rigidbody2D rigidBody2D;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    public GameObject snowBall;
    public Transform shootPoint;

    public AudioSource shootSound;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            rigidBody2D.velocity = new Vector2(-moveSpeed, rigidBody2D.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rigidBody2D.velocity = new Vector2(moveSpeed, rigidBody2D.velocity.y);
        }
        else
        {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
        }

        if (Input.GetKey(down) && !isGrounded)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, -fallSpeed);
        }

        if (Input.GetKeyDown(shoot))
        {
            GameObject ballClone = (GameObject)Instantiate(snowBall, shootPoint.position, shootPoint.rotation);
            ballClone.transform.localScale = transform.localScale;

            anim.SetTrigger("Shoot");

            shootSound.Play();
        }

        if (rigidBody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (rigidBody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed",Mathf.Abs(rigidBody2D.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
}