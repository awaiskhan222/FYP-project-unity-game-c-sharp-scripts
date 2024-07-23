using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CAR_SOUND_SCRIPT : MonoBehaviour
{
    // declearation of the float speed
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    // declear the rigidbody and audiosource 
    private Rigidbody caraudioRb;
    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    // get these variable to access it
    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        caraudioRb = GetComponent<Rigidbody>();
    }

    // This will call the engine sound of the car  
    void Update()
    {
        EngineSound();
    }

    // this is the engine sound function
    // this function will campare  the car sound valume to the car speed
    // and increase and decrease its as for speed
    void EngineSound()
    {
        currentSpeed = caraudioRb.velocity.magnitude;
        pitchFromCar = caraudioRb.velocity.magnitude / 20f;

        if (currentSpeed < minSpeed)
        {
            carAudio.pitch = minPitch;
        }

        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }

        if (currentSpeed > maxSpeed)
        {
            carAudio.pitch = maxPitch;
        }
    }

}
