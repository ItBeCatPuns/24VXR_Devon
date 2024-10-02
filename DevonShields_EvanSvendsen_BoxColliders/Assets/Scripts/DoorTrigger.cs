using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Added to the scene to detect when the player nears the door. Automatically open.
/// </summary>
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioClip chicken;
    [SerializeField] private AudioSource channel;

    private void Start()
    {
        channel.clip = chicken;
    }

    /// <summary>
    ///     Automatically called when the player enters the door region
    /// </summary>
    void OnTriggerEnter()
    {
        doorAnimator.SetBool("IsOpen", true);
        channel.Play();
    }

    /// <summary>
    ///     Automatically called when the player enters the door region
    /// </summary>
    void OnTriggerExit()
    {
        doorAnimator.SetBool("IsOpen", false);
        channel.Play();
    }
}
