using UnityEngine;

public enum MovementType { CenterMovement, CircleSpinMovement }// Interface for different types of movement.
public class ShipMovement : MonoBehaviour
{ 
    public Rigidbody2D rb2D;
    private float thrust = 50f;
    private float torque = 1800f;
    public MovementType movementType;
    private IMovementType iMovementType;
    private AudioClip propellerSound;
    public AudioSource audioSource;
    public MusicManager musicManager;
    private bool mute = false;

    void Start()
    {
        musicManager = GameObject.FindWithTag("MusicManager").GetComponent<MusicManager>(); ;
        HandleMovementType();
        propellerSound = (AudioClip)Resources.Load("PropellerSound");
        audioSource.clip = propellerSound;
        audioSource.Play();
        audioSource.mute = true;
        UpdateSoundEffectMute();
    }
    private void FixedUpdate()
    {
        Movilize();
        if (mute == false)
        {
            if (Input.GetKey(KeyCode.W)) { audioSource.mute = false; }
            else { audioSource.mute = true; }
        }
    }
    private void HandleMovementType()
    {
        Component IWeaponComponent = gameObject.GetComponent<IWeapon>() as Component;//To prevent Unity from creating multiple copies of the same component in inspector at runtime
        if (IWeaponComponent != null) { Destroy(IWeaponComponent); }
        switch (movementType)
        {
            case MovementType.CenterMovement:
                iMovementType = gameObject.AddComponent<CenterMovement>();
                break;
            case MovementType.CircleSpinMovement:
                iMovementType = gameObject.AddComponent<CircleSpinMovement>();
                break;
            default:
                iMovementType = gameObject.AddComponent<CenterMovement>();
                break;
        }
    }
    public void Movilize(){iMovementType.Move(rb2D, thrust, torque);}
    void UpdateSoundEffectMute()
    {
        if (musicManager != null)
        {
            if (musicManager.soundEffectMute == true)
            { audioSource.mute = true; mute = true; }
            else { audioSource.mute = false; mute = false; }
        }
    }
}
