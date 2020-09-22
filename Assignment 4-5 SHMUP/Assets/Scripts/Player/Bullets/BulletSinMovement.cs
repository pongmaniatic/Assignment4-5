using UnityEngine;

public enum BulletCosOrSen { SenMinus, Sen } // -sin and sin make oposing curves. one bullet choses one and the other the other one.
public class BulletSinMovement : MonoBehaviour
{
    public BulletCosOrSen SenMinusOrSen;
    private float xValue;
    void FixedUpdate()// this makes the bullet follow sin() patterns when they are shot.
    {
        switch (SenMinusOrSen)
        {
            case BulletCosOrSen.SenMinus:
                transform.localPosition = new Vector3(0, -Mathf.Sin(xValue) * 0.1f, 0);
                break;
            case BulletCosOrSen.Sen:

                transform.localPosition = new Vector3(0, Mathf.Sin(xValue) * 0.1f , 0);
                break;
            default:
                break;
        }
        xValue += 0.5f;
    }
    void OnBecameInvisible(){Destroy(gameObject);}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")){Destroy(gameObject);}
    }
}
