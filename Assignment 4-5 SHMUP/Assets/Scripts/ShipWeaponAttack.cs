using UnityEngine;

public enum WeaponType { Bullet1, Bullet2 }

public class ShipWeaponAttack : MonoBehaviour
{
    public GameObject weaponMarkerBullet1;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject weaponMarkerBullet2;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject hommingmarker;// turn on or off.
    public GameObject hommingSymbolMaker;// turn on or off.
    public WeaponType weaponType;
    private IWeapon iWeapon;
    private float fireRate = 0.25F;
    private float nextFire = 0.0F;
    //private int weaponCurrentlySelected = 0;// 0 is bullet1 and 1 is bullet2, can be expanded if more weapons are added.
    //private bool hommingUnlocked = false;


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
                weaponMarkerBullet1.SetActive(false);
                weaponMarkerBullet2.SetActive(true);
                break;
            case WeaponType.Bullet1:
                iWeapon = gameObject.AddComponent<Bullet1>();
                weaponMarkerBullet1.SetActive(true);
                weaponMarkerBullet2.SetActive(false);
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
        if (weaponType == WeaponType.Bullet1) { weaponType = WeaponType.Bullet2; }
        else if (weaponType == WeaponType.Bullet2) { weaponType = WeaponType.Bullet1; }
        HandleWeaponType();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        if (col.gameObject.tag == "NewWeapon") { GrabWeapon(); }
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            HandleWeaponType();
            Fire();
        }
    }
}
