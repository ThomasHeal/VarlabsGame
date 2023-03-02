using UnityEngine;

public class Tree : Interactable
{
    public int woodAmount = 10; // The amount of wood that the tree contains
    public AudioClip chopSound; // The sound that should be played when the tree is chopped down
    public TMPro.TextMeshProUGUI woodText;
    private int woodTotal = 0; // maybe make this a global variable?

    // Override the Interact method to define custom behavior for the tree
    public override void Interact()
    {
        if (WeaponSwitcher.weaponNameGlobal != "Axe")
        {
            Debug.Log("Incorrect tool");
            return;
        }
        Global.woodAmount += woodAmount;
        woodTotal = Global.woodAmount;
        woodText.text = $"Wood: {woodTotal}";
        Debug.Log("Chopping down tree...");
    }
}
