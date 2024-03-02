using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List <Transform> patrolPoints;
    public playerController player;
    public float viewAngle;

    private bool _isPlayerNoticed;
    private NavMeshAgent _NavMeshAgent;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }
    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void PatrolUpdate()
    {
        if (_isPlayerNoticed == false) 
        {
            if (_NavMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }
    
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _NavMeshAgent.destination = player.transform.position;
        }
    }

    private void PickNewPatrolPoint()
    {
        _NavMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void InitComponentLinks()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
    }
}
