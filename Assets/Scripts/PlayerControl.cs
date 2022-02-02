using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20.0f;
    private float turnSpeed = 300.0f;
    private float horizontalInput;
    private float verticalInput;
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;
    private float spawnRange = 35;
    public int playerHealth = 100;
    public GameObject[] gunsPrefab;
    private Vector3 offset = new Vector3 (0f, 3f, 0f);
    public bool gunOneEquipped = false;
    public bool gunTwoEquipped = false;
    public bool gunThreeEquipped = false;

    void Start()
    {
        InstantiateEnemies();

    }

    void Update()
    {
        PlayerMovement();
        BulletFire();        
        InstantiateGuns();

    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }

    // Press space to fire //
    private void BulletFire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gunOneEquipped)
        {
            Instantiate(bulletPrefab, transform.position - new Vector3(0, 0.5f, 0), bulletPrefab.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Space) && gunTwoEquipped)
        {
            Instantiate(bulletPrefab, transform.position - new Vector3(0, 0.5f, 0), bulletPrefab.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Space) && gunThreeEquipped)
        {
            Instantiate(bulletPrefab, transform.position - new Vector3(0, 0.5f, 0), bulletPrefab.transform.rotation);
        }
    }
    
    public Vector3 GenerateEnemySpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosinP = new Vector3(spawnPosX, 3.9f, spawnPosZ);
        return randomPosinP;
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemyPrefab, GenerateEnemySpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    // Press 1, 2 and 3 to change guns //
    public void InstantiateGuns()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !gunOneEquipped)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gun2"));
            Destroy(GameObject.FindGameObjectWithTag("Gun3"));
            var newGun1 = Instantiate(gunsPrefab[0], transform.position + offset, gunsPrefab[0].transform.rotation);
            newGun1.transform.parent = gameObject.transform;
            gunOneEquipped = true;
            

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !gunTwoEquipped)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gun1"));
            Destroy(GameObject.FindGameObjectWithTag("Gun3"));
            var newGun2 = Instantiate(gunsPrefab[1], transform.position + offset, gunsPrefab[1].transform.rotation);
            newGun2.transform.parent = gameObject.transform;
            gunTwoEquipped = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !gunThreeEquipped)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gun1"));
            Destroy(GameObject.FindGameObjectWithTag("Gun2"));
            var newGun3 = Instantiate(gunsPrefab[2], transform.position + offset, gunsPrefab[2].transform.rotation);
            newGun3.transform.parent = gameObject.transform;
            gunThreeEquipped = true;
        }
    }
}
