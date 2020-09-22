using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool shieldActive = false;
    private bool shieldRecharging = false;
    private float rechargeRate = 15f;
    private float nextCharge = 0.0f;
    private float shieldLifeSpawn = 5f;
    private float nextShield = 0.0f;
    public GameObject shield;
    public SpriteRenderer shieldSpriteBase;
    public SpriteRenderer shieldSpriteSymbol;


    void Update()
    {
        if (Input.GetKeyDown("space") && shieldRecharging == false && shieldActive == false) {ActivateShields();}
        if (shieldRecharging == true)
        {
            if (Time.time > nextCharge)
            {
                shieldSpriteBase.color = new Color(1, 1, 1, 1);
                shieldSpriteSymbol.color = new Color(1, 1, 1, 1);
                shieldRecharging = false;
            }
        }
        if (shieldActive == true)
        {
            shieldSpriteBase.color = new Color(0, 0, 0, 1);
            shieldSpriteSymbol.color = new Color(0, 0, 0, 1);
            if (Time.time > nextShield) 
            { 
                DeactivatShield(); 
            }
        }

    }

    void ActivateShields()
    {
        shield.SetActive(true); 
        shieldActive = true;
        nextShield = Time.time + shieldLifeSpawn;
    }
    void DeactivatShield()
    {
        shield.SetActive(false);
        shieldActive = false;
        shieldRecharging = true;
        nextCharge = Time.time + rechargeRate;
    }

}
