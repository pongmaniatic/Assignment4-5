using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void MakeHomming()
    {
    }
    public void SetAnimation()
    {
    }
    public void MakeExplosive()
    {
    }
}



