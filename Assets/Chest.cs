using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WIn.playerWinCondition++;
        Destroy(this.gameObject);
    }
}
