using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    public GameObject winMenu;//Gameobject containing the Win menu.
    public GameObject barrier1;//the barriers
    public GameObject barrier2;//the barriers
    public ShipMovement shipMovementScript;//the ships movement script to be able to stop its movement when it reaches win area.
    public int progress = 0;//level of progress means how many stars the player has got.
    void OnTriggerEnter2D(Collider2D other)//when the player touches the Win Area it stops its movement and brings up the win menu.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shipMovementScript.enabled = false;
            winMenu.SetActive(true);
        }
    }
    private void Update()//each star will give 1 progress, meaning one less barrier.
    {
        if (progress == 1) { barrier1.SetActive(false); }
        if (progress == 2) { barrier2.SetActive(false); }
    }
}
