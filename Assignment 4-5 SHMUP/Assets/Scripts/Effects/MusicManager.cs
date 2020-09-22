
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;
    public AudioSource audioSource;
    public bool soundEffectMute = false;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (musicManagerInstance == null){musicManagerInstance = this;}
        else{Destroy(gameObject);}
    }

    public void MuteMusic() { audioSource.mute = !audioSource.mute; }
    public void MuteSoundEffect() { soundEffectMute = !soundEffectMute; }

}
