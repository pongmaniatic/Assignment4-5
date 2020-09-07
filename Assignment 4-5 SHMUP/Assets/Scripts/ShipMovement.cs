using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //private bool CanMove = true;// this is in case I want to make the ship not be able to move.
    //private int Advancing = 0;// -1 is going back, 0 is stationary and 1 is advancing.
    //private int Turning = 0;// -1 is going left, 0 is stationary and 1 is going right. 
    public Rigidbody2D rb2D;
    private float thrust = 0.5f;
    private float torque = 0.02f;

    private void Update()
    {
        #region ShipMovement
        if (Input.GetKey(KeyCode.W)){rb2D.AddForce(transform.right * thrust); }//makes the ship go forwards.
        if (Input.GetKey(KeyCode.S)){rb2D.AddForce(transform.right * -thrust); }//makes the ship go backwards.
        if (Input.GetKey(KeyCode.A)){rb2D.AddTorque(torque); }//makes the ship turn left.
        if (Input.GetKey(KeyCode.D)){rb2D.AddTorque(-torque); }//makes the ship turn right.
        #endregion
    }


}
