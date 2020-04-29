using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private PlayerController player;

    private bool isMoveRight = false;
    private bool isMoveLeft = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (isMoveRight)
        {
            player.MoveRight();
        }

        if (isMoveLeft)
        {
            player.MoveLeft();
        }
    }

    public void MoveRightStart()
    {
        isMoveRight = true;
    }

    public void MoveRightEnd()
    {
        isMoveRight = false;
    }
    public void MoveLeftStart()
    {
        isMoveLeft = true;
    }

    public void MoveLeftEnd()
    {
        isMoveLeft = false;
    }
    public void Jump()
    {
        player.Jump();
    }
    public void ShootFire()
    {
        player.ShootFire();
    }
}
