using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the character's animator component
    public Transform sphereCastPoint; // Reference to the point where the sphere cast should originate from
    public float sphereCastRadius; // Radius of the sphere cast
    public float sphereCastDistance; // Maximum distance of the sphere cast
    public LayerMask interactableLayer; // Layer mask for the objects that are tagged as interactable

    public float swingDelay = 0.5f; // Delay before the player can swing again
    private bool canSwing = true; // Whether the player can swing their tool

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySwingToolAnimation();
        }
    }

    // This function is called when the player swings their tool
    public void PlaySwingToolAnimation()
    {
        // Check if the player can swing their tool
        if (!canSwing)
        {
            return;
        }

        // Play the swing tool animation
        animator.SetTrigger("SwingTool");

        // Perform a sphere cast from the specified point
        RaycastHit[] hits = Physics.SphereCastAll(sphereCastPoint.position, sphereCastRadius, sphereCastPoint.forward, sphereCastDistance, interactableLayer);
        foreach (RaycastHit hit in hits)
        {
            // Check if the object hit is tagged as interactable
            if (hit.collider.CompareTag("Interactable"))
            {
                // Call the interact method on the object
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        // Set the canSwing flag to false
        canSwing = false;

        // Delay the player's ability to swing their tool again
        Invoke("ResetSwingTool", swingDelay);
    }

    // Resets the canSwing flag to true, allowing the player to swing their tool again
    private void ResetSwingTool()
    {
        canSwing = true;
    }
}
