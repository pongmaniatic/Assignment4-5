using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePickUp : MonoBehaviour
{

    private float firePickupRegeneration = 1f;
    private float nextRespawn = 0.0F;
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NewWeapon");
        if (enemies.Length == 0)
        {
            nextRespawn += Time.deltaTime;
            if (nextRespawn > firePickupRegeneration)
            {
                nextRespawn = Time.time + firePickupRegeneration;
                CreateNewPickUp();
                nextRespawn = 0.0f;
            }
        }
    }

    void CreateNewPickUp()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        GameObject weaponPickUp = Instantiate(Resources.Load("WeaponPickUp", typeof(GameObject))) as GameObject;
        weaponPickUp.transform.position = initialPosition;
    }
}
