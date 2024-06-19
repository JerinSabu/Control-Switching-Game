using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackAnimator : MonoBehaviour
{

    public Animator anim;
    InputMaster inputActions;



    public void OnEnable()
    {
        
        inputActions.Enable();
    }


    public void OnDisable()
    {
        inputActions.Disable();
    }


    void Awake()
    {
        inputActions = new InputMaster();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        inputActions.PlayerActions.SAttack.performed += _ => ShortAttackAnimation();
        inputActions.PlayerActions.LAttack.performed += _ => LongAttackAnimation();
    }

    void ShortAttackAnimation()
    {
        PunchHitCheck.Instance.attackPerformed = true;
        DidThePlayerHitMe.instance.attackPerformed = true;
        anim.SetBool("notAttacking", false);
        anim.SetBool("isShortAttacking", true);
        StartCoroutine(Delay());
    }
    void LongAttackAnimation()
    {
        PlayerAttack.Instance.LongAttack();
        anim.SetBool("notAttacking", false);
        anim.SetBool("isLongAttacking", true);
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("notAttacking", true);
        anim.SetBool("isShortAttacking", false);
        anim.SetBool("isLongAttacking", false);
        DidThePlayerHitMe.instance.attackPerformed = false;

    }

}
