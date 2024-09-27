using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [SerializeField] Animator DoorAni;
    void OnTriggerEnter()
    {
        DoorAni.SetBool("IsOpen", true);
    }
    void OnTriggerExit()
    {
        DoorAni.SetBool("IsOpen", false);
    }
}
