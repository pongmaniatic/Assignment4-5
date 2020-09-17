using UnityEngine;

public class DestroyWhenHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamagingFromPlayer")){Destroy(gameObject);}
    }
}
