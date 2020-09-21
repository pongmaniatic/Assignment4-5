using System.Collections.Generic;
using UnityEngine;

public class AttractedToObject : MonoBehaviour
{
    public string[] listOfTags = new string[] { "Player"};
    private GameObject[] allObjectsOfTag;
    private List<GameObject> listOfObjects = new List<GameObject>();
    private float attractThrust = 100.0f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (string tagObject in listOfTags)
        {
            allObjectsOfTag = GameObject.FindGameObjectsWithTag(tagObject);
            foreach (GameObject objects in allObjectsOfTag) { listOfObjects.Add(objects); }
        }
    }

    private void FixedUpdate(){Attract();}

    void Attract()
    {
        foreach (GameObject targetObject in listOfObjects)
        {
            if (targetObject == this.gameObject){continue;}
            float distance = Vector2.Distance(transform.position, targetObject.transform.position);
            if (distance <= 15 && distance > 6)
            {
                Vector2 direction = transform.position - targetObject.transform.position;
                direction.Normalize();
                rb.AddForce(direction * (-attractThrust * distance / 20));
            }
        }
    }
}
