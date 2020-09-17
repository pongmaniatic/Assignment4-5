using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedToObject : MonoBehaviour
{
    private List<string> listOfTags;
    private void Start()
    {
        List<string> Tags = new List<string>();

        Tags.Add("Player");

        listOfTags = Tags;

    }
}
