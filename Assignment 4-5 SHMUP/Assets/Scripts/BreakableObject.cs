using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenSprite1;
    public GameObject brokenSprite2;
    public GameObject brokenSprite3;
    private int brokenlevel = 3;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamagingFromPlayer"))
        {
            brokenlevel -= 1;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (brokenlevel == 2) { brokenSprite1.SetActive(false); }
        if (brokenlevel == 1) { brokenSprite2.SetActive(false); }
        if (brokenlevel <= 0) { Destroy(gameObject); }
    }
}
