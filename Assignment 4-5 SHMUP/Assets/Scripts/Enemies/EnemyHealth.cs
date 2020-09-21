using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHealth = 5;
    public int currentHealth;
    private GameObject enemyManager;
    private EnemyManager enemyManagerScript;

    void Start()
    {
        currentHealth = baseHealth;
        enemyManager = GameObject.FindWithTag("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManager>();
    }

    void Update(){if (currentHealth <= 0) { currentHealth = 0; Death(); }}

    public void HealthMinus(int Damage) { currentHealth -= Damage; }

    void Death()
    {
        enemyManagerScript.UpdateAllObjectsOfTag();
        Destroy(gameObject);
    }
}
