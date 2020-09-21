using System.Collections.Generic;
using UnityEngine;

public class RepelledByObject : MonoBehaviour
{
    private GameObject enemyManager;
    private EnemyManager enemyManagerScript;
    private float repellThrust = 150.0f;
    private Rigidbody2D rb;
    private List<GameObject> listOfObjects;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyManager = GameObject.FindWithTag("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManager>();
    }
    public void FixedUpdate()
    {
        listOfObjects = enemyManagerScript.listOfObjects;
        Repell();
    }

    void Repell()
    {
        foreach (GameObject targetObject in listOfObjects)
        {
            if (targetObject == this.gameObject || !targetObject) { continue; }
            float distance = Vector2.Distance(transform.position, targetObject.transform.position);
            if (distance <= 4)
            {
                Vector2 direction = transform.position - targetObject.transform.position;
                direction.Normalize();
                rb.AddForce(direction * (repellThrust/ (distance)));
            }
        }
    }
}
