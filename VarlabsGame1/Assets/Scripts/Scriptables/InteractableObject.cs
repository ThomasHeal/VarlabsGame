using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Object", menuName = "Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string interactText; // The text that should be displayed when the object is interacted with
    public AudioClip interactSound; // The sound that should be played when the object is interacted with

    // This method can be overridden by subclasses to define custom behavior when the object is interacted with
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + name);
    }
}
