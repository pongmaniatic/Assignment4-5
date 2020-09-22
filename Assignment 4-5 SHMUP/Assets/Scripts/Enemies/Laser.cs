using UnityEngine;

public enum MathType { Sin, SinSinSin, Cos1Sin2 }// using interfaces to determine the equation used by the laser.
public class Laser : MonoBehaviour
{
    public GameObject screenEquation1;//activating and deactivating this show the equation of the laser.
    public GameObject screenEquation2;//activating and deactivating this show the equation of the laser.
    public GameObject screenEquation3;//activating and deactivating this show the equation of the laser.
    public LineRenderer thisLineRenderer;
    public GameObject rotationAxis;//this is a parent of the laser.
    public MathType mathType;
    private IMathType iMathType;
    private float degrees = 0;//this is the degrees of rotation of the axis.
    private float turnChangeRate = 10f;// every 10 seconds the lasers change direction.
    private float nextTurnChange = 0.0f;
    private bool turnDirection = true;// true means degrees going up and false is degrees going down.
    void Start() { HandleMathType(); }
    void FixedUpdate()
    {
        if (turnDirection) { degrees += 0.3f; }//what direction the axis and the lasers turn.
        if (!turnDirection) { degrees -= 0.3f; }//what direction the axis and the lasers turn.
        LineEquation();
        rotationAxis.transform.eulerAngles = Vector3.forward * degrees;//rotates the axis and lasers along with it.
        nextTurnChange += Time.deltaTime;//this increases until it get above 10 and then reverts to 0 again.
        if (nextTurnChange > turnChangeRate)
        {
            nextTurnChange = 0.0f;
            ChangeDirectionAndMath();
        }
    }
    private void HandleMathType()
    {
        Component IMathComponent = gameObject.GetComponent<IMathType>() as Component;//To prevent Unity from creating multiple copies of the same component in inspector at runtime
        if (IMathComponent != null) { Destroy(IMathComponent); }
        switch (mathType)
        {
            case MathType.Sin:
                iMathType = gameObject.AddComponent<Sin>();
                screenEquation1.SetActive(true);
                screenEquation2.SetActive(false);
                screenEquation3.SetActive(false);
                break;
            case MathType.SinSinSin:
                iMathType = gameObject.AddComponent<SinSinSin>();
                screenEquation1.SetActive(false);
                screenEquation2.SetActive(false);
                screenEquation3.SetActive(true);
                break;
            case MathType.Cos1Sin2:
                iMathType = gameObject.AddComponent<Cos1Sin2>();
                screenEquation1.SetActive(false);
                screenEquation2.SetActive(true);
                screenEquation3.SetActive(false);
                break;
            default:
                iMathType = gameObject.AddComponent<Sin>();
                break;
        }
    }

    void ChangeDirectionAndMath()
    {
        if (turnDirection) { turnDirection = false; }//changes direction
        else { turnDirection = true; }//changes direction
        if (mathType == MathType.Sin) { mathType = MathType.SinSinSin; }//changes Equation in this order.
        else if (mathType == MathType.SinSinSin) { mathType = MathType.Cos1Sin2; }//changes Equation in this order.
        else if (mathType == MathType.Cos1Sin2) { mathType = MathType.Sin; }//changes Equation in this order.
        HandleMathType();// Updates the interface.
    }
    public void LineEquation() { iMathType.LineEquation(thisLineRenderer); }
}
