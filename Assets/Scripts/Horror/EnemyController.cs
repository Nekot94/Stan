using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public AudioSource killSource;

    NavMeshAgent agent;
    GameController gameController;

    bool isReachPlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (!isReachPlayer)
            agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isReachPlayer = true;
            killSource.Play();
            collision.gameObject.GetComponent<VRLookWalk>().enabled = false;
            gameController.LooseGame();
        }
    }
}
