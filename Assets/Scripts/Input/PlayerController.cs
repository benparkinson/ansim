using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    Animator animator;

    int isWalkingHash;
    Controls controls;
    Vector2 currentMovement;
    bool movementPressed;
    bool IsGrounded;
    
    private void Start() {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    void HandleMovement(){
        bool isWalking = animator.GetBool(isWalkingHash);

        

        if(movementPressed && !isWalking){
            animator.SetBool(isWalkingHash, true);
        } else if(!movementPressed && isWalking){
            animator.SetBool(isWalkingHash, false);
        }
        controls.Player.Move.canceled += ctx => movementPressed = false;
    }

    void HandleRotation(){
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLookAt = currentPosition + newPosition;
        transform.LookAt(positionToLookAt);
    }


    void OnEnable() {
        controls.Player.Enable();
    }

    void OnDisable() {
        controls.Player.Disable();
    }

    private void Awake() {
        controls = new Controls();
        controls.Player.Move.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
            };
    }

    private void Update() {
        HandleMovement();
        HandleRotation();
    }

    private void FixedUpdate()
    {
    }   

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

}
