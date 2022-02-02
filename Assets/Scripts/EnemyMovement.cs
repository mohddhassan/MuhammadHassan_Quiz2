using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float enemySpeed = 5.0f;
    private Rigidbody enemyRb;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //transform.Translate(lookDirection * enemySpeed);
        enemyRb.AddForce(lookDirection * enemySpeed, ForceMode.VelocityChange);

    }
}
