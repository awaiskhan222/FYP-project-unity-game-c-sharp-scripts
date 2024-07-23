using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Car_Controller : MonoBehaviour
{

    
    //car control variable variable
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    // car tyer variable front and back
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;
        public Axel axel;
    }

    // car physics variable 
    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 400.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    // input floats for car
    float moveInput;
    float steerInput;
    
    // declearation of car body as a rigidbody
    private Rigidbody carRb;

   // in start function we get the body of car and its cnter of mass
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;

    }

    // in update function we get the input from player and call the animate wheel function also
    void Update()
    {
        GetInputs();
        AnimateWheels();
    }

    // in late update we samply call the move and steer function
    void LateUpdate()
    {
        Move();
        Steer();
    }

    // in this function we get input for movment
    public void MoveInput(float input)
    {
        moveInput = input;
    }

    // in this function we get the input for steer
    public void SteerInput(float input)
    {
        steerInput = input;
    }
    
    // function for keyboard
    void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
    }

    // in move function we give torque to the wheel collider to move the car
    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    // in steer function we give angle rotaion for wheel roation
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    // in break function we set the braktorque to brak acceleration
    public void Break()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.brakeTorque = 1000 * brakeAcceleration * Time.deltaTime;
            
        }
    }

    // in releasebreak function we set the torue to zero
    public void Releasebreak()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.brakeTorque = 0;
        }
    }

    // in this function we give animation to the tyre for rotation
    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

}
