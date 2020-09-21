using UnityEngine;

public class WeaponManager : MonoBehaviour{}
public interface IWeapon{void Shoot(); }
public class Bullet1 : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject bullet = Instantiate(Resources.Load("Bullet1", typeof(GameObject))) as GameObject;
        bullet.transform.position = initialPosition;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 15;
    }
}
public class Bullet2 : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject bullet = Instantiate(Resources.Load("Bullet2", typeof(GameObject))) as GameObject;
        bullet.transform.position = initialPosition;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 15;
    }
}
public class Bullet3 : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject bullet = Instantiate(Resources.Load("Bullet4", typeof(GameObject))) as GameObject;
        bullet.transform.position = initialPosition;
        bullet.GetComponent<Bullet>().homming = true;
        bullet.GetComponent<Bullet>().autoDestroy = true;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 15;
    }
}
public class BulletEnemy : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject bullet = Instantiate(Resources.Load("Bullet3", typeof(GameObject))) as GameObject;
        bullet.transform.position = initialPosition;
    }
}


