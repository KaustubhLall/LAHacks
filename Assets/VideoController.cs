using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {
    // Video Player/Handler
    public VideoHandler videoHandler;
    private Transform videoTransform;
    // Camera Attachment
    public Camera mainCamera;
    private bool attachToCamera;

	// Use this for initialization
	void Start () {
        videoTransform = videoHandler.transform;
    }
	
	// Update is called once per frame
	void Update () {
        // Always Look at Camera no matter what;
        //LookAtCamera();

        // This will move the player's position along the camera's movement
        if (attachToCamera)
        {
            videoTransform.parent = mainCamera.transform;
            //LookAtCamera();
        } else
        {
            videoHandler.transform.parent = null;
        }
        /*
         *  Player controls
         */
        // Toggle Pause/Play
        if (Input.GetKeyDown(KeyCode.Space) && videoHandler.IsPlaying)
        {
            videoHandler.Pause();
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            videoHandler.Play();
        // Stop
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            videoHandler.Stop();
        // Replay
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            videoHandler.Replay();
        }
        // Toggle attachment  to camera
        if (Input.GetKeyDown(KeyCode.D))
        {
            attachToCamera = !attachToCamera;
        }

    }
    private void LookAtCamera()
    {
        videoTransform.LookAt(mainCamera.transform);
        videoTransform.Rotate(
            videoTransform.rotation.eulerAngles.x,
            videoTransform.rotation.eulerAngles.y,
            -videoTransform.rotation.eulerAngles.z
        );
    }
}
