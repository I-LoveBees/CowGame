using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;  // The character controller component
    private Vector2 moveInput;           // Input vector for movement
    private Vector3 velocity;               // Current velocity of the character

    // Awake is called when the script instance is initialized
    private void Awake()
    {
        // Get the CharacterController component attached to this GameObject
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        //move
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * (moveSpeed * Time.deltaTime));
        //jump
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
            Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
            if (context.performed && controller.isGrounded)
            {
                Debug.Log($"We are jumping rn");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
    }
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack performed");
            // Implement attack logic here
        }
    }
}
