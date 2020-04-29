using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject Door;
    public SpriteRenderer spriteRenderer;
    public Sprite on;
    public Sprite off;

    public bool Pushed = false;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ice")
        {
            Pushed = true;

            audioSource.Play();
            spriteRenderer.sprite = on;

            if (Door.tag == "ColdWind")
            {
                Door.SetActive(true);
            }
            else
            {
                Door.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Pushed = false;
        spriteRenderer.sprite = off;
        Door.SetActive(true);
    }
    /*
        private void OnCollisionStay2D(Collision2D collision)
        {
            float distance = Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x);

            Debug.Log(distance);

            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ice" && !Pushed && distance < 10)
            {
                Pushed = true;

                audioSource.Play();
                spriteRenderer.sprite = on;
                Door.SetActive(false);   
            }
            else
            {
                Pushed = false;
                spriteRenderer.sprite = off;
                Door.SetActive(true);
            }
            }
            */
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        Pushed = false;
        spriteRenderer.sprite = off;
        Door.SetActive(true);
    }
    */
}
