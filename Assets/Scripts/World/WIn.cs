using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIn : MonoBehaviour
{

    [SerializeField] private Camera myCamera;
    [SerializeField] private GameObject myPlayer;
    
    public static int playerWinCondition;
    [SerializeField] public RuntimeInt levelWinCondition;
    private void Start()
    {
        myCamera = Camera.main;
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        playerWinCondition = 0;

        Vector3 StartPositionPlayer = new Vector3(-4.0f, 0.0f, 0.0f);
        Vector3 StartPositionCamera = new Vector3(0.0f, 0.0f, -10.0f);

        myCamera.transform.position = StartPositionCamera;
        myPlayer.transform.position = StartPositionPlayer;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (playerWinCondition == levelWinCondition.Value)
        {
            myPlayer.transform.position = new Vector3(transform.position.x + 2.0f, transform.position.y);
            myCamera.transform.position = new Vector3(transform.position.x + 5.0f, transform.position.y, -10f);

            playerWinCondition = 0;

            Destroy(this.gameObject);
        }
    }

}
