using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfacerotation : MonoBehaviour
{
    // declear main camera as a variable to acces its components
    public Transform mainCameraTransform;


    // in start function we get the camera to access it
    void Start()
    {
        // Find the main camera in the scene
        mainCameraTransform = Camera.main.transform;
    }

    // in update function we set the player face to rotate alonge with camera
    void Update()
    {
        // Check if the main camera transform is not null
        if (mainCameraTransform != null)
        {
            // Get the rotation of the camera
            Quaternion cameraRotation = mainCameraTransform.rotation;

            // Ignore rotation around the x and z axes (keep the player upright)
            cameraRotation.x = 0f;
            cameraRotation.z = 0f;

            // Rotate the player to face the same direction as the camera
            transform.rotation = cameraRotation;
        }
    }
}
