using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHitCheck : MonoBehaviour
{
    #region Singleton
    public static PunchHitCheck Instance;
    private void Awake()
    {
        Instance = this;

    }

    #endregion
    public bool attackPerformed = false;
    bool attacking = false;
    void OnTriggerEnter(Collider other)
    {
        //if (attackPerformed)
        //{
            if (!attacking)
            {
                if (other.gameObject.tag == "Enemy")
                {
                    PlayerTracker.Instance.ShortAttack();
                }
                attacking = true;
            }
            StartCoroutine(Delay());
        //}

    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        attacking = false;
        attackPerformed = false;


    }
}
