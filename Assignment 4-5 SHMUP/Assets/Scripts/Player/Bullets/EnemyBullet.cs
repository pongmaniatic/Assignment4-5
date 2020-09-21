using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject ship;
    public Vector2 direction;
    public GameObject bullet;
    private Rigidbody2D bulletRigidbody;

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        direction = transform.position - ship.transform.position;
        direction.Normalize();
        this.transform.localEulerAngles = direction;
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible(){Destroy(bullet);}
    private void Update(){bulletRigidbody.AddForce(direction * -0.5f);}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Bullet") && !other.gameObject.CompareTag("Enemy2"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ship.GetComponent<PlayerHealth>().HealthMinus(1);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
