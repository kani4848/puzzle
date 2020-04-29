using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject yuge;
    public GameObject ice;

    public AudioSource audioSource;

    public AudioClip iceSE;
    public AudioClip yugeSE;

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
            audioSource.PlayOneShot(yugeSE);
            Instantiate(yuge, this.transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColdWind")
        {
            count++;
            if (count > 100)
            {
                Destroy(gameObject);
                audioSource.PlayOneShot(iceSE);
                Instantiate(ice, transform.position, Quaternion.identity);
            }
        }
    }
}
