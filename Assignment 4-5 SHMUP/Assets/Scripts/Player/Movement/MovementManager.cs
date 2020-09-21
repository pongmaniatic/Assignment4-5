using UnityEngine;

public class MovementManager : MonoBehaviour{}
public interface IMovementType { void Move(Rigidbody2D rb2D, float Thrust, float Torque); }
public class CenterMovement : MonoBehaviour, IMovementType
{
    public void Move(Rigidbody2D rb2D, float Thrust, float Torque)
    {
        if (Input.GetKey(KeyCode.W)){rb2D.AddForce(transform.right * (Thrust * 0.3f)); }//makes the ship go forwards.
        if (Input.GetKey(KeyCode.S)) { rb2D.AddForce(transform.right * -(Thrust * 0.1f)); }//makes the ship go backwards.
        if (Input.GetKey(KeyCode.A)) { rb2D.AddTorque(((Torque / (Torque * 100)) * 100)); }//makes the ship turn left.
        if (Input.GetKey(KeyCode.D)) { rb2D.AddTorque(-((Torque / (Torque * 100)) * 100)); }//makes the ship turn right.
    }
}
public class CircleSpinMovement : MonoBehaviour, IMovementType
{
    public void Move(Rigidbody2D rb2D, float Thrust, float Torque)
    {
        float rot = Torque * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) { transform.position += 1 * transform.right * Thrust * Time.deltaTime; }//makes the ship go forwards.
        if (Input.GetKey(KeyCode.S)) { transform.position += -1 * transform.right * Thrust * Time.deltaTime; }//makes the ship go backwards.
        if (Input.GetKey(KeyCode.A)) { transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + rot); }//makes the ship turn left.
        if (Input.GetKey(KeyCode.D)) { transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + -rot); }//makes the ship turn right.
    }
}


