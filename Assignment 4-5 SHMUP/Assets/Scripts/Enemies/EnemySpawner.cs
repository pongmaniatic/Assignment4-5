using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float xPositionSpawn = 0.0f;//This position is left public because each spawner is placed in different angles and setting them up manually is easier.
    public float yPositionSpawn = -2.0f;//This position is left public because each spawner is placed in different angles and setting them up manually is easier.
    public float numberOfEnemies = 6;// number of enemies to attempt to create, more than this, and it will not spawn more enemies. less? and it will spawn.
    private GameObject enemyManager;// we need acces to the enemy manager because the enemy manager updates all objects for repelling.
    private EnemyManager enemyManagerScript;
    private float spawnRate = 3f;// delay of a couple of seconds between spawns.
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
        if (pickUps.Length < numberOfEnemies)// only spawn if less enemies than desired.
        {
            nextSpawn += Time.deltaTime;
            if (nextSpawn > spawnRate)
            {
                CreateEnemy();
                enemyManagerScript.UpdateAllObjectsOfTag();// this calls for an update of all objects to take into acount when repelling since there is a new one, its better to do it like this instead of update every frame.
                nextSpawn = 0.0f;
            }
        }
    }
    void CreateEnemy()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x + xPositionSpawn, this.transform.position.y + yPositionSpawn, this.transform.position.z);
        GameObject weaponPickUp = Instantiate(Resources.Load("Enemy2", typeof(GameObject))) as GameObject;//  get the enemy prefab from resources folder.
        weaponPickUp.transform.position = initialPosition;
    }
}
