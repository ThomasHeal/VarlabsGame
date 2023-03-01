using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public GameObject triggerObject;

    public TMPro.TextMeshProUGUI rockText;
    public TMPro.TextMeshProUGUI woodText;
    public TMPro.TextMeshProUGUI hayText;

    public string spawnerType = "";
    public int material;
    bool canSpawn = false;

    private void Start()
    {
        if(this.tag == "RockSpawner")
        {
            spawnerType = "rock";
        }
        if(this.tag == "WoodSpawner")
        {
            spawnerType = "wood";
        }
        if (this.tag == "HaySpawner")
        {
            spawnerType = "hay";
        }
    }

    private void Update()
    {
        switch (spawnerType)
        {
            case "rock":
                material = Global.rockAmount;
                break;
            case "wood":
                material = Global.woodAmount;
                break;
            case "hay":
                material = Global.hayAmount;
                break;
            default:
                break;
        }
        if(material < 30)
        {
            Debug.Log("not enough " + spawnerType);
        }
        if(canSpawn && Input.GetKeyDown(KeyCode.E) && material >= 30)
        {
            switch (spawnerType)
            {
                case "rock":
                    Global.rockAmount = Global.rockAmount - 30;
                    break;
                case "wood": 
                    Global.woodAmount = Global.woodAmount - 30;
                    break;
                case "hay":
                    Global.hayAmount = Global.hayAmount - 30;
                    break;
                default:
                    break;
            }
            rockText.text = $"Rock: {Global.rockAmount}";
            woodText.text = $"Wood: {Global.woodAmount}";
            hayText.text = $"Hay: {Global.hayAmount}";


            Debug.Log("you spawned a monster");
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            canSpawn = true;
            Debug.Log(canSpawn);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == triggerObject)
        {
            canSpawn = false;
            Debug.Log(canSpawn);

        }
    }
}
