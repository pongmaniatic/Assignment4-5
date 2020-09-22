using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private IWeapon iWeapon;//use the weapon interface to get the enemy bullet.
    public float fireRate = 1.5f;// rate of fire.
    private float nextFire = 0.0f;
    private GameObject player;// to get players position.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        iWeapon = gameObject.AddComponent<BulletEnemy>();// adds the interface component to fire enemy bullets.
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= 15 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    public void Fire() { iWeapon.Shoot(); }// shoot!

}
