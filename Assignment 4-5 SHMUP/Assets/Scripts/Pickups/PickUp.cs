using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float scaleRate = 0.005f;
    private float minScale = 0.25f;
    private float maxScale = 0.50f;

    public void ApplyScaleRate(){transform.localScale += Vector3.one * scaleRate;}
    void FixedUpdate(){main();}
    public void main()
    {
        if (transform.localScale.x < minScale){scaleRate = Mathf.Abs(scaleRate);}
        else if (transform.localScale.x > maxScale){scaleRate = -Mathf.Abs(scaleRate);}
        ApplyScaleRate();
    }

}
