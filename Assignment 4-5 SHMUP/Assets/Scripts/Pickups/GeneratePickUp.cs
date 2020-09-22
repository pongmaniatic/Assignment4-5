using UnityEngine;

public class GeneratePickUp : MonoBehaviour
{
    public string pickUpWord;// this string is the name of the object that will be spawned, menaing that if we had more obejcts, we only need to write their name in the editor to generate that object.
    private float spawnRate = 1f;// how often does it spawn a new object after the last one was destroyed.
    private float nextSpawn = 0.0f;
    void Update()
    {
        GameObject[] pickUps = GameObject.FindGameObjectsWithTag(pickUpWord);// get the object prefab to spawn
        if (pickUps.Length == 0)// only one object of this can exist at a time.
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
