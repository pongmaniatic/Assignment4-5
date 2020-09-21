using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePickUp : MonoBehaviour
{
    public string pickUpWord;
    private float spawnRate = 1f;
    private float nextSpawn = 0.0f;
    void Update()
    {
        GameObject[] pickUps = GameObject.FindGameObjectsWithTag(pickUpWord);
        if (pickUps.Length == 0)
        {
            nextSpawn += Time.deltaTime;
            if (nextSpawn > spawnRate)
            {
                nextSpawn = Time.time + spawnRate;
                CreateNewPickUp();
                nextSpawn = 0.0f;
            }
        }
    }

    void CreateNewPickUp()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        GameObject weaponPickUp = Instantiate(Resources.Load(pickUpWord, typeof(GameObject))) as GameObject;
        weaponPickUp.transform.position = initialPosition;
    }
}
