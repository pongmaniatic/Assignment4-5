using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void BackToMenu(){SceneManager.LoadScene("Menu");}
    public void StartGame(){SceneManager.LoadScene("Game");}
}
