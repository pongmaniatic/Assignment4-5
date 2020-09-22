using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int baseHealth = 5;// enemy HP
    private int currentHealth;
    private GameObject enemyManager;//its needed to update relevant objects to repell.
    private EnemyManager enemyManagerScript;

    void Start()
    {
        currentHealth = baseHealth;
        enemyManager = GameObject.FindWithTag("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManager>();
    }

    void Update(){if (currentHealth <= 0) { currentHealth = 0; Death(); }}//if 0 HP then the enemy dies.

    public void HealthMinus(int Damage) { currentHealth -= Damage; }//this substracts life from HP, so we could make different bullets with different damages.

    void Death()
    {
        enemyManagerScript.UpdateAllObjectsOfTag();// update all relevant objects because one is no longer necesary to repell.
        Destroy(gameObject);
    }
}
