using UnityEngine;
using System.Collections;

public enum WeaponType{Bullet1, Bullet2, Bullet3}

public class ShipControler : MonoBehaviour
{
    public WeaponType weaponType;
    private IWeapon iWeapon;

    void Start()
    {
        HandleWeaponType(); //to check the value of weaponType in the inspector initially
    }

    private void HandleWeaponType()
    {      
        Component IWeaponComponent = gameObject.GetComponent<IWeapon>() as Component;//To prevent Unity from creating multiple copies of the same component in inspector at runtime
        if (IWeaponComponent != null){Destroy(IWeaponComponent);}

        #region Strategy
        switch (weaponType)
        {
            case WeaponType.Bullet3:
                iWeapon = gameObject.AddComponent<Bullet3>();
                break;
            case WeaponType.Bullet2:
                iWeapon = gameObject.AddComponent<Bullet2>();
                break;
            case WeaponType.Bullet1:
                iWeapon = gameObject.AddComponent<Bullet1>();
                break;
            default:
                iWeapon = gameObject.AddComponent<Bullet1>();
                break;
        }
        #endregion
    }

    public void Fire(){iWeapon.Shoot();}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){HandleWeaponType();Fire();}
    }
}