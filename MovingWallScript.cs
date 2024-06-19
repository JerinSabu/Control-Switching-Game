using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallScript : MonoBehaviour
{
    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            //Debug.Log("hit");
            if (PlayerTracker.Instance.playerInControl == false)
            {
                PlayerTracker.Instance.playerHealth -= PlayerTracker.Instance.enemyLongAttackDamage;
            }
            else 
            { 
                PlayerTracker.Instance.enemyHealth -= PlayerTracker.Instance.enemyLongAttackDamage;
                //PlayerTracker.Instance.ReduceEnemyHealthLong();
            }
                
            //
            Destroy(gameObject);
        }
    }
}
