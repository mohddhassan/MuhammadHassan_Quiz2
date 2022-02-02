using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 100f;
    private Transform firePoint;
    private Rigidbody bulletRb;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        firePoint = GameObject.Find("FirePoint").transform;
        transform.Translate(firePoint.forward * Time.deltaTime * speed);        
        if (transform.position.z > 43 || transform.position.z < -43 || transform.position.x > 43 || transform.position.x < -43)
        {
            Destroy(gameObject);
        }
               

    }
}
