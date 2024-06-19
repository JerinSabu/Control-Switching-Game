using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject aiPlayer;
    public GameObject playerEnemy;
    public bool playerInControl = true;

    public GameObject camHandler1;
    public GameObject camHandler2;
    public GameObject midCam;
    public Transform playerPosition;
    public Transform enemyPosition;
    public bool switching = false;
    public int level = 3;
    public float currentTime = 0;
    public float maximumSwitchTime = 20;
    public float minimumSwitchTime = 10;
    public float randomSwitchTime = 0;
    public bool gameOver = false;
    public bool playerWon;



    // Update is called once per frame
    void Update()
    {
        CheckGameEnd();
        if (gameOver)
        {
            ManageScenes.userWon = playerWon;
            SceneManager.LoadScene("GameOver");
        }

        PlayerTracker.Instance.playerInControl = playerInControl;
        SwitchingTimer();
        //switching = SwitchingTimer.Instance.switching;

        if (switching)
        {
            
            if (playerInControl)
            {
                SwitchToOpposite();

            }
            else
            {
                SwitchToNormal();
            }
        
        }
        
    }

    void SwitchingTimer()
    {
        if (!switching & randomSwitchTime == 0)
        {
            randomSwitchTime = Random.Range(minimumSwitchTime, maximumSwitchTime);
            

        }
        currentTime += Time.deltaTime;

        if (currentTime >= randomSwitchTime)
        {
            switching = true;
            currentTime = 0;
        }
    }

    void CheckGameEnd()
    {
        if(playerInControl && PlayerTracker.Instance.enemyHealth <= 0)
        {
            ManageScenes.reason = "You Killed the Enemy";
            gameOver = true;
            playerWon = true;
            
        }
        if(playerInControl && PlayerTracker.Instance.playerHealth <= 0)
        {
            ManageScenes.reason = "You died";
            gameOver = true;
            playerWon = false;
            
        }
        if(!playerInControl && (PlayerTracker.Instance.enemyHealth <= 0 || PlayerTracker.Instance.playerHealth <= 0))
        {
            if (PlayerTracker.Instance.playerHealth <= 0)
            {
                ManageScenes.reason = "You killed your Body";
            }
            else ManageScenes.reason = "You died in Enemy's body";
             
            gameOver = true;
            playerWon = false;

        }
    }

    void SwitchToOpposite()
    {
        playerInControl = false;
        switching = false;
        PlayerTracker.Instance.player = playerEnemy;
        playerEnemy.transform.position = enemy.transform.position;
        playerEnemy.transform.rotation = enemy.transform.rotation;

        aiPlayer.transform.position = player.transform.position;
        aiPlayer.transform.rotation = player.transform.rotation;


        //player switches character
        player.SetActive(false);
        playerEnemy.SetActive(true);


        //enemy switches character
        enemy.SetActive(false);
        aiPlayer.SetActive(true);


        //camera switches from player charcter to enemy character
        camHandler2.SetActive(true);
        camHandler1.SetActive(false);
        StartCoroutine(Delay());
        

        //playerEnemy.transform.position = enemy.transform.position;
        
    }

    void SwitchToNormal()
    {
        playerInControl = true;
        switching = false;
        PlayerTracker.Instance.player = player;

        player.transform.position = aiPlayer.transform.position;
        player.transform.rotation = aiPlayer.transform.rotation;

        enemy.transform.position = playerEnemy.transform.position;
        enemy.transform.rotation = playerEnemy.transform.rotation;

        //player switches from ai control to player control
        aiPlayer.SetActive(false);
        player.SetActive(true);


        //enemy switches from Ai control to user Control
        playerEnemy.SetActive(false);
        enemy.SetActive(true);

        //camera switches from enemy charcter to player character
        
        camHandler1.SetActive(true);
        camHandler2.SetActive(false);
        StartCoroutine(Delay());



    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        //if(!playerInControl) camHandler2.SetActive(false);
        //else 


    }

}
