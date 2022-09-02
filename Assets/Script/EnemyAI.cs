using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform _target;
    [SerializeField] float chaseRange = 7f;
    NavMeshAgent _navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(gameObject.transform.position, _target.transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            //_navMeshAgent.SetDestination(_target.position);
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget(); 
        }
        if(distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        _navMeshAgent.SetDestination(_target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);      
        //print(name + " Killed " + _target.name);
    }

    void OnDrawGizmos()
    {
        //Draw a blue sphere at the transform's position
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
