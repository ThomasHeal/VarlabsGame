using UnityEngine;

public class Bone : Interactable
{
    public int boneAmount = 10; // The amount of wood that the tree contains
    public AudioClip crushSound; // The sound that should be played when the tree is chopped down
    public TMPro.TextMeshProUGUI boneText;
    private int boneTotal = 0; // maybe make this a global variable?



    // Override the Interact method to define custom behavior for the tree
    public override void Interact()
    {
        if(WeaponSwitcher.weaponNameGlobal != "Hammer")
        {
            Debug.Log("Wrong tool");
            return;
        }
        Global.boneAmount += boneAmount;
        boneTotal = Global.boneAmount;
        boneText.text = $"{boneTotal}";
        Debug.Log("Crushing Bones...");
    }
}
