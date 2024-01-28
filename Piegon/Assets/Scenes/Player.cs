using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    // Start is called before the first frame update

    private Animator animator;
    private CharacterController characterController;
    private Vector2 movementInput = Vector2.zero;
    private bool hammer = false;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    
        
        
    }

    // Update is called once per frame
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        
    }
    public void OnHammer(InputAction.CallbackContext context)
    {
        hammer = context.action.triggered;

    }
    void Update()
    {
        /*
        float horzInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(horzInput, 0, verticalInput);
        movementDir.Normalize();
        transform.Translate(movementDir * speed * Time.deltaTime, Space.World);
        */
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetBool("isMoving", true);
        }        
        else
        {
            animator.SetBool("isMoving", false);
        }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

        /*
        if (movementDir !=Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            Transform additionalMeshTransform = transform.GetChild(0); // Adjust index if needed
            additionalMeshTransform.position = transform.position;
        }*/

        
        if (Input.GetMouseButtonDown(0))  // 0 corresponds to the left mouse button
        {
            // Do something when the left mouse button is clicked
            animator.SetBool("isHammering", true);

            // Add your custom code here
        }
        else
        {
            animator.SetBool("isHammering", false);
        }
    }
}
