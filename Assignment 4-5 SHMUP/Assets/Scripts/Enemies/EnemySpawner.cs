using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float xPositionSpawn = 0.0f;
    public float yPositionSpawn = -2.0f;
    public float numberOfEnemies = 6;
    private GameObject enemyManager;
    private EnemyManager enemyManagerScript;
    private float spawnRate = 3f;
    private float nextSpawn = 0.0f;
    void Start()
    {
        CreateEnemy();
        enemyManager = GameObject.FindWithTag("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManager>();
    }
    void Update()
    {
        GameObject[] pickUps = GameObject.FindGameObjectsWithTag("Enemy2");
        if (pickUps.Length < numberOfEnemies)
        {
            nextSpawn += Time.deltaTime;
            if (nextSpawn > spawnRate)
            {
                nextSpawn = Time.time + spawnRate;
                CreateEnemy();
                enemyManagerScript.UpdateAllObjectsOfTag();
                nextSpawn = 0.0f;
            }
        }
    }
    void CreateEnemy()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x + xPositionSpawn, this.transform.position.y + yPositionSpawn, this.transform.position.z);
        GameObject weaponPickUp = Instantiate(Resources.Load("Enemy2", typeof(GameObject))) as GameObject;
        weaponPickUp.transform.position = initialPosition;
    }
}
