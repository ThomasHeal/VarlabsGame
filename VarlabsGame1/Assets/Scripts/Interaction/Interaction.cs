using UnityEngine;

public class Interaction : Interactable
{
    public override void Interact()
    {
        // Put your interaction code here
        Debug.Log($"Interacting with {this.name}");
    }
}
