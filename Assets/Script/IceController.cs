using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public GameObject water;
    private bool isMelt = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire" && !isMelt)
        {
            isMelt = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(water, this.transform.position, Quaternion.identity);
        }
    }
}
