using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionWithWall : MonoBehaviour
{
    
    void Start()
    {
        

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            
        }
    }
}
