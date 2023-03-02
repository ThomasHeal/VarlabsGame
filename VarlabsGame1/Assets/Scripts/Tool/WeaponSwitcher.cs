using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weaponPrefabs;
    public Transform weaponParent;
    public int startingWeaponIndex = 0;
    public KeyCode[] weaponKeys;
    public Image[] weaponRenderers;
    public Image weaponImage;
    public TMPro.TextMeshProUGUI weaponNameText;
    public string[] weaponNames;


    private GameObject[] weapons;
    private int currentWeaponIndex;

    void Start()
    {
        // Instantiate all weapon prefabs and disable them
        weapons = new GameObject[weaponPrefabs.Length];
        for (int i = 0; i < weaponPrefabs.Length; i++)
        {
            weapons[i] = Instantiate(weaponPrefabs[i], weaponParent);
            weapons[i].SetActive(false);

            // Set the name of the weapon game object to the corresponding name in the weaponNames array
            weapons[i].name = weaponNames[i];
        }

        // Enable the starting weapon
        currentWeaponIndex = startingWeaponIndex;
        weapons[currentWeaponIndex].SetActive(true);
        SetWeaponUI();
        weaponNameText.text = weaponNames[currentWeaponIndex];
    }


    void Update()
    {
        // Check for user input to switch weapons
        for (int i = 0; i < weaponKeys.Length; i++)
        {
            if (Input.GetKeyDown(weaponKeys[i]))
            {
                SwitchToWeapon(i);
            }
        }
    }

    void SwitchToWeapon(int index)
    {
        // Disable the current weapon
        weapons[currentWeaponIndex].SetActive(false);

        // Update the current weapon index
        currentWeaponIndex = index;

        // Enable the new current weapon
        weapons[currentWeaponIndex].SetActive(true);

        // Get the name of the current weapon from the weaponNames array
        string weaponName = weaponNames[currentWeaponIndex];

        // Print the name of the current weapon to the console
        Debug.Log("Switched to weapon: " + weaponName);

        // Set the name of the current weapon in the TextMeshProUGUI component
        weaponNameText.text = weaponName;

        // Update the UI to show the new current weapon
        SetWeaponUI();
    }


    void SetWeaponUI()
    {
        // Get the material of the current weapon
        Material weaponMaterial = weaponRenderers[currentWeaponIndex].material;

        // Set the material of the weapon image on the UI
        weaponImage.material = weaponMaterial;
    }
}
