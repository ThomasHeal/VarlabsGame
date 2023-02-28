using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // Public variables
    public Transform player; // The player's transform
    public float distance = 6.0f; // The distance between the camera and the player
    public float minDistance = 2.0f; // The minimum distance between the camera and the player
    public float maxDistance = 10.0f; // The maximum distance between the camera and the player
    public float height = 3.0f; // The height of the camera above the player
    public float rotationDamping = 3.0f; // The speed at which the camera rotates
    public float fixedAngle = 45.0f; // The fixed angle of the camera above the player
    public float minVerticalAngle = 5.0f; // The minimum vertical angle of the camera
    public float maxVerticalAngle = 85.0f; // The maximum vertical angle of the camera
    public float verticalRotationSpeed = 3.0f; // The speed at which the camera rotates vertically
    public float heightChangeSpeed = 3.0f; // The speed at which the camera's height changes

    // Private variables
    private Vector3 targetPosition; // The position the camera is trying to reach
    private float horizontalAngle = 0.0f; // The horizontal angle of the camera
    private float verticalAngle = 0.0f; // The vertical angle of the camera

    void LateUpdate()
    {
        // Calculate the target position
        targetPosition = player.position - Quaternion.Euler(verticalAngle, horizontalAngle, 0.0f) * Vector3.forward * distance + Vector3.up * height;

        // Move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, rotationDamping * Time.deltaTime);

        // Lock the camera's rotation to a fixed angle above the player
        transform.rotation = Quaternion.Euler(new Vector3(fixedAngle, horizontalAngle, 0.0f));

        // Handle horizontal rotation input
        float mouseX = Input.GetAxis("Mouse X");
        horizontalAngle += mouseX;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -180.0f, 180.0f);

        // Handle zoom and height input
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance += scroll * 5.0f;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        height += scroll * heightChangeSpeed;
        height = Mathf.Clamp(height, 0.0f, maxDistance);

        // Rotate the player to face the camera direction
        Quaternion cameraRotation = Quaternion.Euler(0.0f, horizontalAngle, 0.0f);
        Vector3 cameraDirection = cameraRotation * Vector3.forward;
        player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(cameraDirection), rotationDamping * Time.deltaTime);
    }
}
