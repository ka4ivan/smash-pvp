using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public float ballSpped;

    private Rigidbody2D rigidBody2D;

    public GameObject snowBallDestroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(ballSpped * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player 1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }

        if(other.tag == "Player 2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }

        Instantiate(snowBallDestroyEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
