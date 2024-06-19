using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongAttackDetection : MonoBehaviour
{
    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            /*if (PlayerTracker.Instance.playerInControl)
            {
                PlayerTracker.Instance.playerHealth -= PlayerTracker.Instance.enemyLongAttackDamage;
            }
            
            else PlayerTracker.Instance.enemyHealth -= PlayerTracker.Instance.enemyLongAttackDamage;
            */

            if (PlayerTracker.Instance.playerInControl == false)
            {
                PlayerTracker.Instance.enemyHealth -= PlayerTracker.Instance.enemyLongAttackDamage;
            }
            else
            {
                PlayerTracker.Instance.playerHealth -= PlayerTracker.Instance.enemyLongAttackDamage;
                
                //PlayerTracker.Instance.ReduceEnemyHealthLong();
            }
            Debug.Log("hit");
            //PlayerTracker.Instance.LongAttack();
            Destroy(gameObject);
        }
    }
}
