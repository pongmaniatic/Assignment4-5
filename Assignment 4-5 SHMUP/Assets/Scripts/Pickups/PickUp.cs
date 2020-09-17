using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class PickUp : MonoBehaviour
{
    public float scaleRate = 0.001f;
    public float minScale = 0.25f;
    public float maxScale = 0.50f;

 public void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate;
    }

    public void main()
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }

    void Update()
    {
        main();

    }
}
