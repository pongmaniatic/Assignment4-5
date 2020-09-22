using System.Collections.Generic;
using UnityEngine;

public class RepelledByObject : MonoBehaviour
{
    private GameObject enemyManager;// gets the enemy manager to get its script.
    private EnemyManager enemyManagerScript;// this script updates a list of relevant object to reppel against.
    private float repellThrust = 150.0f;// how strongly it reppels.
    private Rigidbody2D rb;//this objects rigid body.
    private List<GameObject> listOfObjects;// the list of relevant object.
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyManager = GameObject.FindWithTag("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManager>();
    }
    public void FixedUpdate()
    {
        listOfObjects = enemyManagerScript.listOfObjects;// get the most updated list! this is an optimization, that way not all enemies have to individually calculate the same list.
        Repell();
    }
    void Repell()
    {
        foreach (GameObject targetObject in listOfObjects)// goes through the list and if its close enough it adds a repelling force from tha object.
        {
            if (targetObject == this.gameObject || !targetObject) { continue; }// this stops the object from reppeling from itself or from an object that was destroyed and would cause an error.
            float distance = Vector2.Distance(transform.position, targetObject.transform.position);//distance to see how close they are, the closer, the stronger the repell is.
            if (distance <= 4)//only repell if its this close.
            {
                Vector2 direction = transform.position - targetObject.transform.position;//calculate the vector towards the target.
                direction.Normalize();//make the magnitud 1.
                rb.AddForce(direction * (repellThrust/ (distance)));//add force away from the target depending on distance.
            }
        }
    }
}
