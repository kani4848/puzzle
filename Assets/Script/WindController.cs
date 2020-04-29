using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public float speed = 0;
    public float banishPoint = 0;
    // Start is called before the first frame update
    
    private void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);

        float distance = Mathf.Abs(transform.position.x - banishPoint);
        if(distance < 5)
        {
            Destroy(gameObject);
        }
    }
}
