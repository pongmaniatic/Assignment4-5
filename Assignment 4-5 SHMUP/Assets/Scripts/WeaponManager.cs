using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour{}
public interface IWeapon{void Shoot(); }
public class Bullet1 : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x + 1f, this.transform.position.y , -1);
        GameObject bullet = Instantiate(Resources.Load("Bullet1", typeof(GameObject))) as GameObject;
        bullet.transform.position = initialPosition;
        //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0f);
    }
}
public class Bullet2 : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x + 1f, this.transform.position.y, -1);
        GameObject missile = Instantiate(Resources.Load("Bullet2", typeof(GameObject))) as GameObject;
        missile.transform.position = initialPosition;
        //missile.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0f);
    }
}
public class Bullet3 : MonoBehaviour, IWeapon
{
    public void Shoot()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x + 1f, this.transform.position.y, -1);
        GameObject missile = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
        missile.transform.position = initialPosition;
        //missile.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0f);
    }
}

