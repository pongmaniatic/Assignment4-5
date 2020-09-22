using UnityEngine;

public class SuperComputer : MonoBehaviour
{

    public GameObject screenDead;
    public GameObject screenAlive;
    public GameObject objectiveStar;
    public GameObject WinArea;
    private SpriteRenderer sprite;


    void Start()
    {
        sprite = objectiveStar.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("PcCristal").Length < 1)
        {
            WinArea.GetComponent<WinArea>().progress += 1;
            screenDead.SetActive(true);
            screenAlive.SetActive(false);
            sprite.color = new Color(1, 1, 1, 1);
        }
    }


}
