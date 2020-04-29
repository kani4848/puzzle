using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public GameObject water;
    private bool isMelt = false;

    public AudioSource audioSource;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire" && !isMelt)
        {
            isMelt = true;
            audioSource.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(water, this.transform.position, Quaternion.identity);
        }
    }
}
