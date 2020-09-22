using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { Bullet1, Bullet2, Bullet3 }

public class ShipWeaponAttack : MonoBehaviour
{
    public GameObject weaponMarkerBullet1;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject weaponMarkerBullet2;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject weaponMarkerBullet3;// get the weapon icon to put the right image of the weapon currently selected.
    public GameObject hommingmarker;// turn on or off.
    public GameObject hommingSymbolMaker;// turn on or off.
    public PlayerHealth playerHealthComponent;
    public WeaponType weaponType;
    private IWeapon iWeapon;
    private float fireRate = 0.25f;// rate of fire for player weapon.
    private float nextFire = 0.0f;
    private int Weapon = 0;
    private List<int> UnlockedWeapons = new List<int>();// a list of all unlocked weapons, it starts with only one type of bullet unlocked, it can have 3 in total.
    private float invincivilitySeconds = 3f;// seconds of invincivility after being hit by the laser
    private float nextInvincivilityOff = 0.0f;
    private bool invincivility = false;
    public AudioClip GunSound1;
    public AudioClip GunSound2;
    public AudioClip GunSound3;
    public AudioSource audioSource;
    public MusicManager musicManager;

    void Start()//to check the value of weaponType in the inspector initially and adds the first type of bullet.
    {
        musicManager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>(); 
        HandleWeaponType(); 
        UnlockedWeapons.Add(0);
        UpdateSoundEffectMute();
    }
    private void HandleWeaponType()
    {
        Component IWeaponComponent = gameObject.GetComponent<IWeapon>() as Component;//To prevent Unity from creating multiple copies of the same component in inspector at runtime
        if (IWeaponComponent != null) { Destroy(IWeaponComponent); }
        switch (weaponType)
        {
            case WeaponType.Bullet3:
                iWeapon = gameObject.AddComponent<Bullet3>();
                weaponMarkerBullet1.SetActive(false);
                weaponMarkerBullet2.SetActive(false);
                weaponMarkerBullet3.SetActive(true);
                audioSource.clip = GunSound3;
                fireRate = 1f;
                break;
            case WeaponType.Bullet2:
                iWeapon = gameObject.AddComponent<Bullet2>();
                weaponMarkerBullet1.SetActive(false);
                weaponMarkerBullet2.SetActive(true);
                weaponMarkerBullet3.SetActive(false);
                audioSource.clip = GunSound2;
                fireRate = 0.3f;
                break;
            case WeaponType.Bullet1:
                iWeapon = gameObject.AddComponent<Bullet1>();
                weaponMarkerBullet1.SetActive(true);
                weaponMarkerBullet2.SetActive(false);
                weaponMarkerBullet3.SetActive(false);
                audioSource.clip = GunSound1;
                fireRate = 0.5f;
                break;
            default:
                iWeapon = gameObject.AddComponent<Bullet1>();
                weaponMarkerBullet1.SetActive(true);
                weaponMarkerBullet2.SetActive(false);
                weaponMarkerBullet3.SetActive(false);
                audioSource.clip = GunSound1;
                fireRate = 0.5f;
                break;
        }
    }
    void Fire() { iWeapon.Shoot(); audioSource.Play(); }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WeaponPickUp") { Destroy(col.gameObject); GrabWeapon(); }
        if (col.gameObject.tag == "HealthPickUp") { Destroy(col.gameObject); playerHealthComponent.HealthAdd(10); }
        if (col.gameObject.tag == "Laser")
        {
            if (!invincivility){ playerHealthComponent.HealthMinus(2); invincivility = true; }// get hurt by the laser.
        }

    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            HandleWeaponType();
            Fire();
        }
        if (Input.GetKeyUp(KeyCode.Q)) { SwitchWeaponLeft(); }// used to change between unlocked guns manually
        if (Input.GetKeyUp(KeyCode.E)) { SwitchWeaponRight(); }// used to change between unlocked guns manually
        if (invincivility)
        {
            nextInvincivilityOff += Time.deltaTime;
            if (nextInvincivilityOff > invincivilitySeconds)
            {
                nextInvincivilityOff = 0.0f;
                invincivility = false;
            }
        }
    }
    void UpdateWeapon()
    {
        if (Weapon == 0) { weaponType = WeaponType.Bullet1; }
        if (Weapon == 1) { weaponType = WeaponType.Bullet2; }
        if (Weapon == 2) { weaponType = WeaponType.Bullet3; }
        HandleWeaponType();
    }
    void GrabWeapon()
    {
        if (Weapon == 0) { Weapon = 1; }
        else if (Weapon == 1) { Weapon = 2; }
        else if (Weapon == 2) { Weapon = 0; }
        if (UnlockedWeapons.Count == 1) { UnlockedWeapons.Add(1); Weapon = 1; }
        else if (UnlockedWeapons.Count == 2) { UnlockedWeapons.Add(2); Weapon = 2; }
        UpdateWeapon();
    }
    void SwitchWeaponRight()
    {
        if (UnlockedWeapons.Count != 1)
        {
            if (UnlockedWeapons.Count == 2)
            {
                if (Weapon == 0) { Weapon = 1; }
                else if (Weapon == 1) { Weapon = 0; }
            }
            else
            {
                if (Weapon == 0) { Weapon = 1; }
                else if (Weapon == 1) { Weapon = 2; }
                else if (Weapon == 2) { Weapon = 0; }
            }
        }
        UpdateWeapon();
    }
    void SwitchWeaponLeft()
    {
        if (UnlockedWeapons.Count != 1)
        {
            if (UnlockedWeapons.Count == 2)
            {
                if (Weapon == 1) { Weapon = 0; }
                else if (Weapon == 0) { Weapon = 1; }
            }
            else
            {
                if (Weapon == 2) { Weapon = 1; }
                else if (Weapon == 1) { Weapon = 0; }
                else if (Weapon == 0) { Weapon = 2; }
            }
        }
        UpdateWeapon();
    }
    void UpdateSoundEffectMute()
    {
        if (musicManager != null)
        {
            if (musicManager.soundEffectMute == true)
            { audioSource.mute = true; }
            else { audioSource.mute = false; }
        }
    }
}
