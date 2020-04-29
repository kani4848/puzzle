using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YugeController : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, 1, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
