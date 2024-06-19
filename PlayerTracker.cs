using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTracker : MonoBehaviour
{
    #region Singleton
    public static PlayerTracker Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject player;


    public int enemyShortAttackDamage = 5;
    public int enemyLongAttackDamage = 2;
    public int playerHealth = 20;
    public int enemyHealth = 20;
    public int maxHealth =20 ;
    public bool playerInControl = true;
    public TextMeshProUGUI playerH;
    public TextMeshProUGUI enemyH;



    private void Update()
    {
        playerH.text = playerHealth.ToString();
        enemyH.text = enemyHealth.ToString();
    }


    public void ShortAttack()
    {
        if (playerInControl)
        {
            playerHealth -= enemyShortAttackDamage;
        }
        else enemyHealth -= enemyShortAttackDamage;
        
    }

    public void LongAttack()
    {
        if (playerInControl)
        {
            playerHealth -= enemyLongAttackDamage;
        }
        else enemyHealth -=enemyLongAttackDamage;
        
    }
    public void PlayerLongAttack()
    {
        if (playerInControl)
        {
            enemyHealth -= enemyLongAttackDamage;
        }
        else playerHealth -= enemyLongAttackDamage;
    }


    public void ReduceEnemyHealth()
    {
        enemyHealth -= enemyShortAttackDamage;
    }


    public void ReduceEnemyHealthLong()
    {
        enemyHealth -= enemyLongAttackDamage;
    }

}
