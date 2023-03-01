using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public GameObject triggerObject;

    public TMPro.TextMeshProUGUI rockText;

    public string spawnerType = "";
    public int material;
    bool canSpawn = false;

    private void Start()
    {
        if(this.tag == "RockSpawner")
        {
            spawnerType = "rock";
        }
    }

    private void Update()
    {
        switch (spawnerType)
        {
            case "rock":
                material = Global.rockAmount;
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
            Global.rockAmount = Global.rockAmount - 30;
            rockText.text = $"Rock: {Global.rockAmount}";
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
