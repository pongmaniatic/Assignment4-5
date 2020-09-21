using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenSprite1;
    public GameObject brokenSprite2;
    public GameObject brokenSprite3;
    public int brokenlevel = 3;
    private int maxBrokenLevel;

    private void Start(){ maxBrokenLevel = brokenlevel;}

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
        if (brokenlevel <= ((maxBrokenLevel / 3) * 2)) { brokenSprite1.SetActive(false); }
        if (brokenlevel <= ((maxBrokenLevel / 3) * 1)) { brokenSprite2.SetActive(false); }
        if (brokenlevel <= 0) { Destroy(gameObject); }
    }
}
