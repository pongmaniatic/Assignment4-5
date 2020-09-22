using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool shieldActive = false;// if the shield is on or off.
    private bool shieldRecharging = false;// if the shield is recharging.
    private float rechargeRate = 15f;// how much it takes to recharge.
    private float nextCharge = 0.0f;
    private float shieldLifeSpawn = 5f;// how much the shield lasts.
    private float nextShield = 0.0f;
    public GameObject shield;
    public SpriteRenderer shieldSpriteBase;//this is needed to show the icon that tells the player if the shield is ready to use.
    public SpriteRenderer shieldSpriteSymbol;//this is needed to show the icon that tells the player if the shield is ready to use.
    void Update()
    {
        if (Input.GetKeyDown("space") && shieldRecharging == false && shieldActive == false) {ActivateShields();}// activate the shield with space if its possible.
        if (shieldRecharging == true)// after the shields power end it will start to recharge and the icon will be black.
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
