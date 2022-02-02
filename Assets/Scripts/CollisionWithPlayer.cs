using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    private GameObject playerGO;
    private GameObject enemyGO;
    
    void Start()
    {
        playerGO = GameObject.Find("Player");
        enemyGO = GameObject.Find("Enemy");
    }

    void Update()
    {
        
    }

    // If enemy collides with player it destroys itself and player's health is decreased by 10
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerGO.GetComponent<PlayerControl>().playerHealth -= 10;
            Destroy(collision.gameObject);
            Debug.Log(playerGO.GetComponent<PlayerControl>().playerHealth);
            
        }

        


    }
}
