using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraMoveSpeed = 250.0f;// how fast the camera moves.
    public GameObject cameraFollowObj;// what object the camera follows, the player prefab had a new empty oject added to it, that one is used as the object being followed for this scene.
    private void LateUpdate() { CameraUpdater(); } //this makes sure the camera update is done last, so to avoid a jittery camera.
    void CameraUpdater()
    {
        Transform target = cameraFollowObj.transform;// define the position of the player.
        float step = cameraMoveSpeed * Time.deltaTime;// how fast the camera will move.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);// moves the camera holder so it smoothly stays with the player.
    }

}
