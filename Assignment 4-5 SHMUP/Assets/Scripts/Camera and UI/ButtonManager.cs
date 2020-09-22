using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void BackToMenu(){SceneManager.LoadScene("Menu");}// go to menu
    public void StartGame(){SceneManager.LoadScene("Game");}//go to game
}
