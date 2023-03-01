using UnityEngine;
using UnityEngine.AI;

public class AIPathfinding : MonoBehaviour
{
    public Transform player; // The player to follow

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(player.position); // Set the target to the player's position
    }
}
