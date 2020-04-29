using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmiController : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <= transform.position.y+20)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }
}
