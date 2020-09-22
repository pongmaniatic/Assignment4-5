using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour{ }
public interface IMathType { void LineEquation(LineRenderer thisLineRenderer); }
public class Sin : MonoBehaviour, IMathType
{
    public void LineEquation(LineRenderer thisLineRenderer)
    {
        float segmentWidth = 0.2f;
        thisLineRenderer.positionCount = 100;
        for (int i = 0; i < 100; i++)
        {
            float xLine = segmentWidth * i;
            float yLine = Mathf.Sin(xLine + Time.time * 4) / 2;
            thisLineRenderer.SetPosition(i, new Vector3(xLine, yLine, 0.0f));
        }
    }
}
public class SinSinSin : MonoBehaviour, IMathType
{
    public void LineEquation(LineRenderer thisLineRenderer)
    {
        float segmentWidth = 0.2f;
        thisLineRenderer.positionCount = 100;
        for (int i = 0; i < 100; i++)
        {

            float xLine = segmentWidth * i;
            float yEcuation = Mathf.Sin(xLine + Time.time * 4);
            float yLine = Mathf.Pow(yEcuation, 3);
            thisLineRenderer.SetPosition(i, new Vector3(xLine, yLine, 0.0f));
        }
    }
}
public class Cos1Sin2 : MonoBehaviour, IMathType
{
    public void LineEquation(LineRenderer thisLineRenderer)
    {
        float segmentWidth = 0.2f;
        thisLineRenderer.positionCount = 100;
        for (int i = 0; i < 100; i++)
        {
            float xLine = segmentWidth * i;
            float ylineEcuation = (Mathf.Cos(xLine + Time.time * 4)) * (Mathf.Sin(xLine * 2 + Time.time * 4));
            float yLine = ylineEcuation ;
            thisLineRenderer.SetPosition(i, new Vector3(xLine, yLine, 0.0f));
        }
    }
}
