using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagaer : MonoBehaviour
{
    private PlayerController player;

    public GameObject clear;
    public AudioSource audioSource;
    public AudioClip clearSound;
    public GameObject actionButton;
    public GameObject stageButton;

    public bool isGoal = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        clear.SetActive(false);
        stageButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGoal && !isGoal)
        {
            clear.SetActive(true);
            audioSource.PlayOneShot(clearSound);
            isGoal = true;
            actionButton.SetActive(false);
            stageButton.SetActive(true);
        }
    }

}
