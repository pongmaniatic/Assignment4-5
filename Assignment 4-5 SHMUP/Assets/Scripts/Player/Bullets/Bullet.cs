using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string[] listOfTags = new string[] { "Enemy","Enemy2", "Spawner" };
    private GameObject[] allObjectsOfTag;
    private List<GameObject> listOfObjects = new List<GameObject>();
    private Transform ship;
    public bool homming = false;
    public bool autoDestroy = false;
    private float attractThrust = 50.0f;
    private Rigidbody2D rb;
    private GameObject closestEnemy;
    private float closestDistance = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindWithTag("Player").transform;
        this.transform.localEulerAngles = ship.localEulerAngles;
        UpdateList();
        if (autoDestroy) { Destroy(gameObject,5); }
    }
    void OnBecameInvisible(){ Destroy(gameObject);}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
            {
                other.gameObject.GetComponent<EnemyHealth>().HealthMinus(1);
                Destroy(gameObject);
            }
            Destroy(gameObject);    
        }
    }
    private void FixedUpdate()
    {
        if (homming == true){UpdateList();Attract();}
    }

    void UpdateList()
    {
        foreach (string tagObject in listOfTags)
        {
            allObjectsOfTag = GameObject.FindGameObjectsWithTag(tagObject);
            foreach (GameObject objects in allObjectsOfTag) 
            {
                float distance = Vector2.Distance(transform.position, objects.transform.position);
                listOfObjects.Add(objects);
                if (distance < closestDistance){closestEnemy = objects;}
            }
        }
    }

    void Attract()
    {
        if (closestEnemy)
        {
            float distance = Vector2.Distance(transform.position, closestEnemy.transform.position);
            if (distance <= 10)
            {
                Vector2 direction = transform.position - closestEnemy.transform.position;
                direction.Normalize();
                rb.AddForce(direction * (-attractThrust * distance / 20));
            }
        }
    }
}



