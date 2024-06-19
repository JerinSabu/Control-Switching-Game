using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{

    #region Singleton
    public static CameraSwitching instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject target;
    public GameObject midPoint;
    public float speed =1;
    public bool mid = false;
    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mid)
        {
            transform.position = Vector3.MoveTowards(transform.position, midPoint.transform.position, speed);

        }
        
        if(transform.position == midPoint.transform.position && mid)
        {
            mid = true;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

        }
        if(transform.position == target.transform.position && mid)
        {
            done = true;
        }
    }
}
