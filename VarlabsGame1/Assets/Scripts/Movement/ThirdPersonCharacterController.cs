using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    // Public variables
    public float speed = 6.0f; // Movement speed
    public float jumpSpeed = 8.0f; // Jump speed
    public float gravity = 20.0f; // Gravity
    public float rotateSpeed = 3.0f; // Rotation speed
    public Animator anim; // Animator component

    // Private variables
    private Vector3 moveDirection = Vector3.zero; // Movement direction
    private CharacterController controller; // Character controller component
    private Transform cameraTransform; // Camera transform component

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>(); // Get the character controller component
        cameraTransform = Camera.main.transform; // Get the camera transform component
    }

    void Update()
    {

        // Check if the character is grounded
        if (controller.isGrounded)
        {
            // Get the horizontal and vertical input
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Set the movement direction based on the input and camera's forward vector
            Vector3 forward = cameraTransform.forward;
            forward.y = 0.0f;
            forward.Normalize();
            Vector3 horizontal = Vector3.Cross(Vector3.up, forward);
            moveDirection = forward * verticalInput + horizontal * horizontalInput;
            moveDirection *= speed;

            // Rotate the character to face the movement direction
            if (moveDirection.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotateSpeed * Time.deltaTime);
            }

            // Set the running animation state
            bool isRunning = (horizontalInput != 0 || verticalInput != 0);
            anim.SetBool("isRunning", isRunning);

            // Jump if the Jump button is pressed
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }


        // Move the character controller
        controller.Move(moveDirection * Time.deltaTime);
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // Stop the character's movement when the input is released



    }
}
