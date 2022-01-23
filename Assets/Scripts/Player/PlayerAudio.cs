using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private RuntimeBool walkingRef;
    [SerializeField] private RuntimeBool interactingRef;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource dragSound;

    void Update()
    {
        if (walkingRef.Value)
        {
            dragSound.Stop();
            walkSound.Play();
        }
        if (interactingRef.Value)
        {
            walkSound.Stop();
            dragSound.Play();
        }
        //if (!interactingRef.Value || !walkingRef.Value)
        //{
        //    walkSound.Stop();
        //    dragSound.Stop();

        //}
    }
}
