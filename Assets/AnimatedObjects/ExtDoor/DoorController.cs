using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
