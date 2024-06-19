using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidThePlayerHitMe : MonoBehaviour
{
    #region Singleton
    public static DidThePlayerHitMe instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public bool attacking = false;
    public bool attackPerformed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (attackPerformed) 
        { 
            if (!attacking)
            {
                if (other.gameObject.tag == "Player")
                {
                    PlayerTracker.Instance.ReduceEnemyHealth();
                }
                attacking = true;
            }


        }
    }
}
