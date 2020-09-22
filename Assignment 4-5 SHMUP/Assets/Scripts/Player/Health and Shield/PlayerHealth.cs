using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject DeathMenu;
    public int baseHealth = 10;
    public int currentHealth;
    public ShipMovement shipMovementScript;
    private GameObject healthSprite;
    private SpriteRenderer healthSpriteRenderer;


    void Start()
    {
        healthSprite = GameObject.FindWithTag("HealthSprite");
        healthSpriteRenderer = healthSprite.GetComponent<SpriteRenderer>();
        currentHealth = baseHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0) { currentHealth = 0; Death(); }
        if (currentHealth >= 10) { currentHealth = 10; }
        UpdateHealthSprite();
    }

    void UpdateHealthSprite()
    {
        float spriteWidth = (0.3f * currentHealth);
        float adjustPosition = (-300 + (7 * currentHealth));
        healthSpriteRenderer.size = new Vector3(spriteWidth, 0.58f, 0.0f);
        healthSprite.transform.localPosition = new Vector3(adjustPosition, -260, 0.0f);
    }
    public void HealthAdd(int Heal){currentHealth += Heal;}

    public void HealthMinus(int Damage) { currentHealth -= Damage; }
    void Death() 
    {
        shipMovementScript.enabled = false;
        DeathMenu.SetActive(true);
    }
}
