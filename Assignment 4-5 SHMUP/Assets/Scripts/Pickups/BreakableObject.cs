using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenSprite1;//deactivate to show the sprite behind showing progress of damage.
    public GameObject brokenSprite2;//deactivate to show the sprite behind showing progress of damage.
    public GameObject brokenSprite3;//deactivate to show the sprite behind showing progress of damage.
    public int brokenlevel = 3;// how destoryed it is. basically its HP
    private int maxBrokenLevel;

    private void Start(){ maxBrokenLevel = brokenlevel;} // save the max HP value to do math and know when to show the right sprite.

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamagingFromPlayer"))// only player bullets hurt it.
        {
            brokenlevel -= 1;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (brokenlevel <= ((maxBrokenLevel / 3) * 2)) { brokenSprite1.SetActive(false); }// changes sprite after reaching two thirds HP 
        if (brokenlevel <= ((maxBrokenLevel / 3) * 1)) { brokenSprite2.SetActive(false); }// changes sprite after reaching one third HP 
        if (brokenlevel <= 0) { Destroy(gameObject); }
    }
}
