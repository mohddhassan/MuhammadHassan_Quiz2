using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithBullets : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    // If a bullet collides with the enemy, enemy and bullet both destroy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
