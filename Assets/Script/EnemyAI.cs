using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 7f;

    NavMeshAgent _navMeshAgent;
    Transform _target;

    public float turnSpeed = 1f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
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

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();    
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
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - gameObject.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmos()
    {
        //Draw a blue sphere at the transform's position
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
