using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public MusicManager musicManager;
    private void Start(){musicManager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>();}
    public void BackToMenu(){SceneManager.LoadScene("Menu");}// go to menu
    public void StartGame(){SceneManager.LoadScene("Game");}//go to game
    public void SendMuteMusic(){musicManager.MuteMusic();}// this is so it always refers to the current version of musicManager instead of the version that was destroyed.
    public void SendMuteSoundEffect(){musicManager.MuteSoundEffect(); }// this is so it always refers to the current version of musicManager instead of the version that was destroyed.

}
