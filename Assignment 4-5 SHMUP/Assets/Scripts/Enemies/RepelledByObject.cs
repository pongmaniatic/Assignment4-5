using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelledByObject : MonoBehaviour
{
    private List<string> listOfTags;
    private void Start()
    {
        List<string> Tags = new List<string>();

        Tags.Add("Enemy");
        Tags.Add("Obstacle");

        listOfTags = Tags;

    }


}
