using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private string[] listOfTags = new string[] { "Enemy", "Obstacle", "Enemy2", "Spawner" };// this are all the tags that identify objects that will be consider when repelling.
    private GameObject[] allObjectsOfTag;//  a list of each group of tags.
    public List<GameObject> listOfObjects = new List<GameObject>();// a list of all relevant objects.

    public GameObject objectiveStar;// this is needed to brighten the star when all spawners are defeated.
    public GameObject WinArea;// needed to tell the win area to open the another door.
    private SpriteRenderer sprite;

    public void Start()
    {
        UpdateAllObjectsOfTag();
        sprite = objectiveStar.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Spawner").Length < 1)//detects that all spawners are detroyed.
        {
            WinArea.GetComponent<WinArea>().progress += 1;//tells win area to open another door because of the progress.
            sprite.color = new Color(1, 1, 1, 1);// make the star bright and visible with color instead of dark.
        }
    }

    public void UpdateAllObjectsOfTag()
    {
        foreach (string tagObject in listOfTags)//go through all tag groups.
        {
            allObjectsOfTag = GameObject.FindGameObjectsWithTag(tagObject);// all objects of that tag group
            foreach (GameObject objects in allObjectsOfTag) { listOfObjects.Add(objects); }// add to the list each object of that tag group to get all objects of every tag group.
        }
    }
    
}
