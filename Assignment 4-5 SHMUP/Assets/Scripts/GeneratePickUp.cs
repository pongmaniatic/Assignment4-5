using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePickUp : MonoBehaviour
{

    private float firePickupRegeneration = 2f;
    private float nextFire = 0.0F;
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("NewWeapon").Length == 0 && Time.time > nextFire)
        {
            
            nextFire = Time.time + firePickupRegeneration;
            CreateNewPickUp();
        }
        
    }

    void CreateNewPickUp()
    {

        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        GameObject weaponPickUp = Instantiate(Resources.Load("WeaponPickUp", typeof(GameObject))) as GameObject;
        weaponPickUp.transform.position = initialPosition;

    }
}
