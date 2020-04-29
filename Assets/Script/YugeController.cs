using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YugeController : MonoBehaviour
{

    public AudioSource audioSource;

    public GameObject water;
    void Update()
    {
  //      transform.Translate(0, 1, 0);
//        transform.position += new Vector3(0, 1, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;

        if (colTag == "ColdWind")
        {
            float distanse = Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x);

            if (distanse < 2)
            {
                audioSource.Play();
                Destroy(gameObject);
                Instantiate(water, transform.position, Quaternion.identity);
            }
        }

        if (colTag == "Wind")
        {
            transform.Translate(collision.gameObject.GetComponent<WindController>().speed, 0, 0);
        }
    }
}
