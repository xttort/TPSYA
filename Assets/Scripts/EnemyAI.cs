using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List <Transform> patrolPoints;
    public playerController player;
    public float viewAngle;
    public float damage = 30;
    private playerHealth pH;

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
        AttackUpdate();
    }

    private void PatrolUpdate()
    {
        if (_isPlayerNoticed == false) 
        {
            if (_NavMeshAgent.remainingDistance <= _NavMeshAgent.stoppingDistance)
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
        pH = player.GetComponent<playerHealth>();
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_NavMeshAgent.remainingDistance <= _NavMeshAgent.stoppingDistance)
            {
                pH.giveDmg(damage*Time.deltaTime);
            }
        }
            
    }
}
