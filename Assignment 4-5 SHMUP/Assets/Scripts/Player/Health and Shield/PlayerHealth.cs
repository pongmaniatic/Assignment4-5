using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int baseHealth = 5;
    public int currentHealth;
    private GameObject healthSprite;
    public SpriteRenderer healthSpriteRenderer;

    private void Start()
    {
        healthSprite = GameObject.FindWithTag("HealthSprite");
        healthSpriteRenderer = healthSprite.GetComponent<SpriteRenderer>();
        currentHealth = baseHealth;
    }

    private void Update()
    {
        UpdateHealthSprite();
        if (currentHealth <= 0) { currentHealth = 0; Death(); }
        if (currentHealth > 10) { currentHealth = 10; }
    }

    void UpdateHealthSprite()
    {
        float spriteWidth = (0.3f * currentHealth);
        float adjustPosition = (-300 + (7 * currentHealth));
        healthSpriteRenderer.size = new Vector3(spriteWidth, 0.58f, 0.0f);
        healthSprite.transform.localPosition = new Vector3(adjustPosition, -265, 0.0f);
    }
    void HealthAdd(int Heal){currentHealth += Heal;}

    void HealthMinus(int Damage) { currentHealth -= Damage; }
    void Death() 
    { 
       //insert player death
    }
}
