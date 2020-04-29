using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirController : MonoBehaviour
{
    public Animator puroperaAnim;
    public GameObject wind;
    private GameObject windIns;
    public AudioSource audioSource;

    private float nextTime = 0;
    private bool isWork = false;

    private void Start()
    {
        puroperaAnim.SetTrigger("isOff");
    }

    private void FixedUpdate()
    {
        if (isWork && nextTime < Time.time)
        {
            windIns = Instantiate(wind, this.transform.position, Quaternion.identity);
            WindController windPara = windIns.GetComponent<WindController>();
            windPara.speed = 1;
            windPara.banishPoint = 44;

            nextTime = Time.time + 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Yuge")
        {
            Destroy(collision.gameObject);
            puroperaAnim.SetTrigger("isOn");
            isWork = true;
            audioSource.Play();
        }
    }
}
