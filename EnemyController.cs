using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public bool attackPerformed = false;
    public float attackRange = 5f;
    public float attackDelay = 5;
    public bool checkForNewAttack = true;
    
    

    
    void Start()
    {
        target = PlayerTracker.Instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

   
    void Update()
    {
       


        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            EnemyAnimationController.instance.isWalking = true;
            if (distance > agent.stoppingDistance && distance <= attackRange && !attackPerformed)
            {
                //Debug.Log("doing long attack");
                LongAttack();
            }
            
            
            if (distance <= agent.stoppingDistance)
            {
                EnemyAnimationController.instance.isWalking = false;
                FaceTarget();
                if (attackPerformed == false)
                {
                    //Debug.Log("doing Short attack");
                    ShortAttack();
                
                }

            }
        }
    }

    

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void ShortAttack()
    {
        ShortAttackHitCheck.Instance.attackPerformed = true;
        EnemyAnimationController.instance.isShortAttacking = true;
        
        //checks for collision, if true, reduces health on player tracker.
        
        attackPerformed = true;
        StartCoroutine(AttackDelay());

    }

    void LongAttack()
    {

        EnemyAnimationController.instance.isLongAttacking = true;
        EnemyAttack.Instance.LongAttack();
        attackPerformed = true;
        StartCoroutine(AttackDelay());
    }


    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        attackPerformed = false;
    }


}
