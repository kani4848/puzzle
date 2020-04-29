using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 2;
    private float nextTime = 0;

    public GameObject fire;
    public bool isLand = true;
    public bool isWater = false;
    public bool isGoal = false;

    private AudioSource audioSource;

    public AudioClip jumpSE;
    public AudioClip fireSE;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //左に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        // 右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        //火を打つ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootFire();
        }

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.X))
        {
            Jump();
        }
    }

    public void MoveRight()
    {
        if (!isGoal)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += new Vector3(speed, 0.0f, 0.0f);
        }
    }

    public void MoveLeft()
    {
        if (!isGoal)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position -= new Vector3(speed, 0.0f, 0.0f);
        }
    }

    public void ShootFire()
    {
        if (!isGoal)
        {
            if (nextTime < Time.time)
            {
                audioSource.PlayOneShot(fireSE);
                Instantiate(fire, this.transform.position, Quaternion.identity);
                nextTime = Time.time + 1;
            }
        }
    }

    public void Jump()
    {
        if (!isGoal)
        {
            if (isLand)
            {
                audioSource.PlayOneShot(jumpSE);
                isLand = false;
                rb.AddForce(transform.up * 15000f);
            }

            if (isWater)
            {

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string objTag = collision.gameObject.tag;

        switch (objTag)
        {
            case "Water":
                isWater = true;
                break;

            case "Ice":
                isLand = true;
                break;

            case "Block":
                isLand = true;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string objTag = collision.gameObject.tag;

        switch(objTag){
            case "Water":
                isWater = true;
                break;

            case "Ice":
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    transform.position = new Vector3(collision.gameObject.transform.position.x - 32, transform.position.y, 0);
                }
                else
                {
                    transform.position = new Vector3(collision.gameObject.transform.position.x + 32, transform.position.y, 0);
                }
                break;

            case "Block":
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    transform.position = new Vector3(collision.gameObject.transform.position.x - 32, transform.position.y, 0);
                }
                else
                {
                    transform.position = new Vector3(collision.gameObject.transform.position.x + 32, transform.position.y, 0);
                }
                break;

            case "Goal":
                float distance = Mathf.Abs(collision.gameObject.transform.position.x - transform.position.x);

                if (distance < 20)
                {
                    isGoal = true;
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
