using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject ship;// need the player ship to get a direction where the bullet goes towards.
    private Vector2 direction;
    public GameObject bullet;// just to destroy the parent of both bullets instead of just the bullets and end up with an invisible parent of a bullet.
    private Rigidbody2D bulletRigidbody;

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        direction = transform.position - ship.transform.position;// get the direction
        direction.Normalize();// set the magnitude to 1
        this.transform.localEulerAngles = direction; // make the bullet face the direction its going.
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible(){Destroy(bullet);}// destroys the bullet when the camera can no longer see it.
    private void Update(){bulletRigidbody.AddForce(direction * -0.5f);}// just makes the bullet move forwards.

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Bullet") && !other.gameObject.CompareTag("Enemy2"))// the bullet does not care about colliding with other enemies or other enemy bullets.
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ship.GetComponent<PlayerHealth>().HealthMinus(1);// this take one point of HP from the player.
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
