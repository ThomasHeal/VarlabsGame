using UnityEngine;

public class Rock : Interactable
{
    public int rockAmount = 10; // The amount of wood that the tree contains
    public AudioClip mineSound; // The sound that should be played when the tree is chopped down
    public TMPro.TextMeshProUGUI rockText;
    private int rockTotal = 0; // maybe make this a global variable?

    // Override the Interact method to define custom behavior for the tree
    public override void Interact()
    {
        if(WeaponSwitcher.weaponNameGlobal != "PickAxe")
        {
            Debug.Log("Wrong tool");
            return;
        }
        Global.rockAmount += rockAmount;
        rockTotal = Global.rockAmount;
        rockText.text = $"{rockTotal}";
        Debug.Log("Mining Rock...");
        // Play chopping animation and spawn wood
    }
}
