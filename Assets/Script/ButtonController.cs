using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Undo()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
    public void Go1()
    {
        // Sceneの読み直し
        SceneManager.LoadScene("stage1");
    }

    public void Go2()
    {
        // Sceneの読み直し
        SceneManager.LoadScene("stage2");
    }
    public void Go3()
    {
        // Sceneの読み直し
        SceneManager.LoadScene("stage3");
    }
}
