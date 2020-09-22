using UnityEngine;

public class AttractedToObject : MonoBehaviour
{
    private GameObject Player;//the player ship.
    private float attractThrust = 100.0f;// how strong is the attraction.
    private Rigidbody2D rb;// the rigidbody of this object.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();// get the rigidbody 
        Player = GameObject.FindGameObjectWithTag("Player");// get player
    }
    private void FixedUpdate(){Attract();}
    void Attract()
    {
            float distance = Vector2.Distance(transform.position, Player.transform.position); // get the distance, because the closer it is to the player, the weaker the attraction.
            if (distance <= 15 && distance > 6)// too close and the enemy stops getting closer.
            {
                Vector2 direction = transform.position - Player.transform.position;//calculate the vector towards the target.
            direction.Normalize();//make the magnitud 1.
            rb.AddForce(direction * (-attractThrust * distance / 20));//add force towardsy the target depending on distance.
        }
    }
}
