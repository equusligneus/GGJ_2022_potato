using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIn : MonoBehaviour
{

    [SerializeField] Camera myCamera;
    [SerializeField] GameObject myPlayer;

    private void Start()
    {
        myCamera = Camera.main;
        myPlayer = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter with:" + collision.gameObject.name);
        myPlayer.transform.position = new Vector3(transform.position.x + 2.0f, transform.position.y);
        myCamera.transform.position = new Vector3(transform.position.x + 5.0f, transform.position.y, -10f);

    }

}
