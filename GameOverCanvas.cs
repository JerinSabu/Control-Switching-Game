using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    public TextMeshProUGUI gameResult;
    public TextMeshProUGUI resultReason;
    
    void Awake()
    {
        
        resultReason.text = ManageScenes.reason;
        if (ManageScenes.userWon)
        {
            gameResult.text = "You Won";
            gameResult.color = Color.green;
        }
        else
        {
            gameResult.text = "You Lost";
            gameResult.color = Color.red;
        }
        
        
    }

    
    
}
