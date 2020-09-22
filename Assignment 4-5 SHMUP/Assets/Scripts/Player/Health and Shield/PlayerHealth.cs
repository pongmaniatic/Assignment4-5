using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject DeathMenu;// this menu is activated when the player dies.
    public int baseHealth = 10;// HP
    public int currentHealth;
    public ShipMovement shipMovementScript;// this is needed to stop the player of moving after it dies.
    private GameObject healthSprite;// this health sprite is tiled and will generate more copies of itself if it is streched.
    private SpriteRenderer healthSpriteRenderer;
   
    void Start()
    {
        healthSprite = GameObject.FindWithTag("HealthSprite");
        healthSpriteRenderer = healthSprite.GetComponent<SpriteRenderer>();
        currentHealth = baseHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0) { currentHealth = 0; Death(); }// when HP is 0 it does and shows a menu. also health can not be lower than zero.
        if (currentHealth >= 10) { currentHealth = 10; }// can not be higher than 10.
        UpdateHealthSprite();
    }
    void UpdateHealthSprite()
    {
        float spriteWidth = (0.3f * currentHealth);// the width of how much the sprite is streched will determine the amount of health bars that appear.
        float adjustPosition = (-4.2f + (0.1f * currentHealth));// since the sprite streches from both sides, its position needs to be adjusted.
        healthSpriteRenderer.size = new Vector3(spriteWidth, 0.58f, 0.0f);
        healthSprite.transform.localPosition = new Vector3(adjustPosition, 0, 0.0f);
    }
    public void HealthAdd(int Heal){currentHealth += Heal;}
    public void HealthMinus(int Damage) { currentHealth -= Damage; }
    void Death() 
    {
        shipMovementScript.enabled = false;// deactivate movement control.
        DeathMenu.SetActive(true);//show death menu.
    }
}
