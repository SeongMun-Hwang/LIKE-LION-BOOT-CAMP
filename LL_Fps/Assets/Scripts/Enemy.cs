using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        agent.destination = player.transform.position;
    }
    private void Update()
    {
        if (agent.remainingDistance < 1f)
        {
            agent.destination = player.transform.position;
        }
    }
}