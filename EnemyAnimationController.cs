using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    #region Singleton
    public static EnemyAnimationController instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public bool isWalking = false;
    public bool isShortAttacking = false;
    public bool isLongAttacking = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (isShortAttacking)
        {
            anim.SetBool("isShortAttacking", true);
            StartCoroutine(Delay());

        }
        else anim.SetBool("isShortAttacking", false);

        if (isLongAttacking)
        {
            anim.SetBool("isLongAttacking", true);
            StartCoroutine(Delay());

        }
        else anim.SetBool("isLongAttacking", false);

        if (isWalking)
        {
            
            anim.SetBool("isWalking", true);
        }
        else anim.SetBool("isWalking", false);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        isShortAttacking = false;
        isLongAttacking = false;
        
    }
}
