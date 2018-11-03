using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;



[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyAIController : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public Transform target;                                    // target to aim for
    private Weapon weapon;
    private float timeSinceTargetAcquisition = 0;
    private bool targetAcquired = false;

    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = true;
        agent.updatePosition = true;
        weapon = GetComponent<Weapon>();
        weapon.SetIsEnemyWeapon(true);
    }


    private void Update()
    {

        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance) { 
            targetAcquired = false;
            timeSinceTargetAcquisition = 0;
        }       
        else
        {
            targetAcquired = true;
            transform.LookAt(target);
            if (timeSinceTargetAcquisition >= weapon.weaponItem.timeToFireAfterReachingTarget)
            {
                weapon.Fire();
            } else
            {
                timeSinceTargetAcquisition += Time.deltaTime;
            }
            
        }
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
