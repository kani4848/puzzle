using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public bool isRight = true;
    private Vector3 speed = new Vector3(3, 0, 0);
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.transform.localScale.x == -1)
        {
            isRight = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRight)
        {
            transform.position += speed;
        }
        else
        {
            transform.position -= speed;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(gameObject);
    } 
}