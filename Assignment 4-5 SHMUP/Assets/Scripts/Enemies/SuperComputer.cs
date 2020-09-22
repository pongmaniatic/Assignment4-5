using UnityEngine;

public class SuperComputer : MonoBehaviour
{

    public GameObject turnAxis;// deactivating this stops the lasers.
    public GameObject screenDead;//activating this shows the computer died.
    public GameObject objectiveStar;//this star is darkened, so i take the renderer to change the color to normal.
    public GameObject WinArea;//tell the winning area progress is being made.
    private SpriteRenderer sprite;//hange the color to normal.


    void Start(){sprite = objectiveStar.GetComponent<SpriteRenderer>();}//get renderer.
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("PcCristal").Length < 1)//check if all life cristals are destroyed.
        {
            WinArea.GetComponent<WinArea>().progress += 1;//send progress that opens a door to the exit.
            screenDead.SetActive(true);
            turnAxis.SetActive(false);
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
