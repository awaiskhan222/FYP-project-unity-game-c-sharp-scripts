using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class My_player_controll : MonoBehaviour
{
    // decleration of variables
    //get the charactercontroller script

    private CharacterController controller;

    // declear player velocity in vector 3
    private Vector3 playerVelocity;

    // declear bool for gorunded player
    private bool groundedPlayer;

    // decleration of float spee,hight,gravity
    [SerializeField]
    private float rotationSpeed = 4f;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private Transform cameraMian;
    [SerializeField]

    // declear the animator as a variable to acces it
    private Animator anim;

    // declear and set a value for lyerindex for animation rigging to achive the aiming
    public int lyerindex = 1;
    public  float lyerWeight_AIMING_OFF = 0f;
    public float lyerWeight_AIMING_ON = 1f;

    public Rig rigComponent;

    // declearation of the gameobject to access it for activation
    private Playerfacerotation facerotaionscript;
    public GameObject shooting_icon;
    public GameObject shooting_mood_off_icon;
    public GameObject shooting_mood_on_icon;

    // get the my player function 
    private Myplayer playercontrol;
    private Transform child;

    // get the audiosource
    private AudioSource footstep;

    
    // the function on awake will set the playercontroll and controller variable
    private void Awake()
    {
        
        playercontrol = new Myplayer();
        controller = GetComponent<CharacterController>();    
    }


    // the function will enable the script
    private void OnEnable()
    {
        playercontrol.Enable();
    }
    // the function will disable the script
    private void OnDisable()
    {
        playercontrol.Disable();
    }
   
    // in start funtion will deleare the variable to get access
    private void Start()
    {       
        cameraMian = Camera.main.transform;
        child = transform.GetChild(0).transform;
        anim = GetComponent<Animator>();
        facerotaionscript = GetComponent<Playerfacerotation>();
  
    }

    // this function off the shooting mood
    public void Shooting_Mood_OFF()
    {
        if(anim != null)
        {
            anim.SetLayerWeight(lyerindex, lyerWeight_AIMING_OFF);
            facerotaionscript.enabled = false;

            SetRigWeight(0f);
            shooting_icon.SetActive(false);
            shooting_mood_off_icon.SetActive(false);
            shooting_mood_on_icon.SetActive(true);
        }
        

    }

    // this function ON the shooting mood
    public void Shooting_Mood_ON()
    {
        if (anim != null)
        {
            anim.SetLayerWeight(lyerindex, lyerWeight_AIMING_ON);
            facerotaionscript.enabled = true;

            SetRigWeight(1f);
            shooting_icon.SetActive(true);
            shooting_mood_off_icon.SetActive(true);
            shooting_mood_on_icon.SetActive(false);
        }


    }

    // this function will set the weight for aim animation rigging
    public void SetRigWeight(float weight)
    {
        if (rigComponent != null)
        {
            rigComponent.weight = weight;
            
        }
        
    }
    
    // the function will check the player if it grounded then it give move the player
    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            
        }

        // this will check the inputsystem and get the value and and then move the player in it direction
        Vector2 movementInput = playercontrol.Player.Move.ReadValue<Vector2>();
        Vector3 move = (cameraMian.forward * movementInput.y + cameraMian.right * movementInput.x);
        move.y = 0f;
        controller.Move(playerSpeed * Time.deltaTime * move );

        // the function will activate the runnig animation if the move condition is true
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            anim.SetBool("running", true);
            

        }
        // this function will deactivate the runnig aniamtion
        else
        {
            anim.SetBool("running", false);
            
        }
       
        // here will aplly the gravity in y_axis before the move function 
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }

    
    

}
