using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Bullet1, Bullet2 }

public class ShipWeaponAttack : MonoBehaviour
{
    public GameObject WeaponMarkerBullet1;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject WeaponMarkerBullet2;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject Hommingmarker;// turn on or off.
    public GameObject HommingSymbolMaker;// turn on or off.
    public WeaponType weaponType;
    private IWeapon iWeapon;
    private int WeaponCurrentlySelected = 0;// 0 is bullet1 and 1 is bullet2, can be expanded if more weapons are added.
    private bool SecondBulletUnlocked = false;
    private bool HommingUnlocked = false;


    void Start()
    {
 
        HandleWeaponType(); //to check the value of weaponType in the inspector initially
    }

    private void HandleWeaponType()
    {
        Component IWeaponComponent = gameObject.GetComponent<IWeapon>() as Component;//To prevent Unity from creating multiple copies of the same component in inspector at runtime
        if (IWeaponComponent != null) { Destroy(IWeaponComponent); }
        #region Strategy
        switch (weaponType)
        {
            case WeaponType.Bullet2:
                iWeapon = gameObject.AddComponent<Bullet2>();
                WeaponMarkerBullet1.SetActive(true);
                WeaponMarkerBullet2.SetActive(true);
                break;
            case WeaponType.Bullet1:
                iWeapon = gameObject.AddComponent<Bullet1>();
                WeaponMarkerBullet1.SetActive(true);
                WeaponMarkerBullet2.SetActive(false);
                break;
            default:
                iWeapon = gameObject.AddComponent<Bullet1>();
                break;
        }
        #endregion
    }

    public void Fire() { iWeapon.Shoot(); }
    public void GrabWeapon()
    {
        if (weaponType == WeaponType.Bullet1)
        {
            weaponType = WeaponType.Bullet2;
        }
        else if (weaponType == WeaponType.Bullet2)
        {
            weaponType = WeaponType.Bullet1;
        }
        HandleWeaponType();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "NewWeapon")
        {
            GrabWeapon();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { HandleWeaponType(); Fire(); }
    }
}
