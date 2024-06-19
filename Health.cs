using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerTracker.Instance.playerInControl)
            {
                PlayerTracker.Instance.playerHealth = PlayerTracker.Instance.maxHealth;
            }
            else PlayerTracker.Instance.enemyHealth = PlayerTracker.Instance.maxHealth;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }
}
