using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingTimer : MonoBehaviour
{
    #region Singelton
    public static SwitchingTimer Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    

    private void Update()
    {
        
    }

}
