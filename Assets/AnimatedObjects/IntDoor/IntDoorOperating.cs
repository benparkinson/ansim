using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntDoorOperating : MonoBehaviour
{
    private Animator animator;

    private void OnTriggerEnter(Collider other) 
    {
        animator.SetBool("doorTriggered", true);
    }

    private void OnTriggerExit(Collider other) 
    {
        animator.SetBool("doorTriggered", false);
    }
}
