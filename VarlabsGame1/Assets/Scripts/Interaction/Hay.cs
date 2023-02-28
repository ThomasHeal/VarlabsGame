using UnityEngine;

public class Hay : Interactable
{
    public int hayAmount = 10; // The amount of wood that the tree contains
    public AudioClip cutSound; // The sound that should be played when the tree is chopped down
    public TMPro.TextMeshProUGUI hayText;
    private int hayTotal = 0; // maybe make this a global variable?



    // Override the Interact method to define custom behavior for the tree
    public override void Interact()
    {
        Global.hayAmount += hayAmount;
        hayTotal = Global.hayAmount;
        hayText.text = $"Hay: {hayTotal}";
        Debug.Log("Cutting Wheat..");
        // Play chopping animation and spawn wood
    }
}
