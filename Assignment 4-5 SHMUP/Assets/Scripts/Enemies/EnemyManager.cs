using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private string[] listOfTags = new string[] { "Enemy", "Obstacle", "Enemy2", "Spawner" };
    private GameObject[] allObjectsOfTag;
    public List<GameObject> listOfObjects = new List<GameObject>();

    public GameObject objectiveStar;
    public GameObject WinArea;
    private SpriteRenderer sprite;

    public void Start()
    {
        UpdateAllObjectsOfTag();
        sprite = objectiveStar.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Spawner").Length < 1)
        {
            WinArea.GetComponent<WinArea>().progress += 1;
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    public void UpdateAllObjectsOfTag()
    {
        foreach (string tagObject in listOfTags)
        {
            allObjectsOfTag = GameObject.FindGameObjectsWithTag(tagObject);
            foreach (GameObject objects in allObjectsOfTag) { listOfObjects.Add(objects); }
        }
    }
    
}
