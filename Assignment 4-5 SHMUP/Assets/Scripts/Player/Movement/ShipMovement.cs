using UnityEngine;

public enum MovementType { CenterMovement, CircleSpinMovement }
public class ShipMovement : MonoBehaviour
{ 
    public Rigidbody2D rb2D;
    private float thrust = 5f;
    private float torque = 180f;

    public MovementType movementType;
    private IMovementType iMovementType;

    void Start(){HandleMovementType();}

    private void Update(){Movilize();}

    private void HandleMovementType()
    {
        Component IWeaponComponent = gameObject.GetComponent<IWeapon>() as Component;//To prevent Unity from creating multiple copies of the same component in inspector at runtime
        if (IWeaponComponent != null) { Destroy(IWeaponComponent); }
        #region Movement Strategy
        switch (movementType)
        {
            case MovementType.CenterMovement:
                iMovementType = gameObject.AddComponent<CenterMovement>();
                break;
            case MovementType.CircleSpinMovement:
                iMovementType = gameObject.AddComponent<CircleSpinMovement>();
                break;
            default:
                iMovementType = gameObject.AddComponent<CenterMovement>();
                break;
        }
        #endregion 
    }

    public void Movilize(){iMovementType.Move(rb2D, thrust, torque);}

}
