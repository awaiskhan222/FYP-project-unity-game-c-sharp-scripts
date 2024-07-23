using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CAR_EXIT_AND_ENTER : MonoBehaviour
{

    // decleration of variable
    private AudioSource caraudio;

    public CinemachineFreeLook cinecamera;


    public Transform newfollowtarget;
    public Transform newlooktarget;

    public Transform OLDfollowtarget;
    public Transform OLDlooktarget;


    // get the carcontroller script
    public MonoBehaviour CarController;
    
    // decleration of car and playe as an object
    public Transform Car;
    public Transform Player;

    
    public GameObject PlayerCam;
    public GameObject CarCam;

    public GameObject DriveUi;
    public GameObject PLAYERUi;

    public GameObject CAR_ENTER_UI;
    public GameObject CAR_EXIT_UI;

    public GameObject MENU_UI;

    // get the my player controll script
    private My_player_controll plyerscript;

    bool Candrive;



    // Start is called before the first frame update
    void Start()
    {
        CarController.enabled = false;
        
        DriveUi.gameObject.SetActive(false);
        caraudio = GetComponent<AudioSource>();
        

        GameObject player = GameObject.Find("Player");
        plyerscript = player.GetComponent<My_player_controll>(); 
        

    }
    public void Menucall()
    {
        MENU_UI.SetActive(true);
    }

    public void RESUME_GAME()
    {
        MENU_UI.SetActive(false);
    }
    public void RESTART_GAME(int n)
    {
        SceneManager.LoadScene(n);
    }
    public void QUIT_GAME()
    {
        Application.Quit();
    }
    //car exit function
    public void CAREXIT()
    {
        
        CarController.enabled = false;
        Player.transform.SetParent(null);
        Player.gameObject.SetActive(true);
        PLAYERUi.SetActive(true);
        DriveUi.SetActive(false);
        CAR_EXIT_UI.gameObject.SetActive(false);
        caraudio.enabled = false;
        // calling the shooting function
        plyerscript.Shooting_Mood_OFF();




        // set the camera after car exit
        if (cinecamera != null)
        {
            this.cinecamera.m_Follow = OLDfollowtarget;
            this.cinecamera.m_LookAt = OLDlooktarget;

            cinecamera.m_Orbits[1].m_Radius = 4;
            cinecamera.m_Orbits[2].m_Radius = 1;

        }

    
    }
    //car enter function
    public void ENTERCAR()
    {         
            CarController.enabled = true;
            
            DriveUi.gameObject.SetActive(true);
            PLAYERUi.gameObject.SetActive(false);

            CAR_ENTER_UI.gameObject.SetActive(false);
            CAR_EXIT_UI.gameObject.SetActive(true);

            // Here we parent Car with player
            Player.transform.SetParent(Car);
            Player.gameObject.SetActive(false);
            caraudio.enabled = true;
        // set the camera after car enter
        if (cinecamera != null)
            {
                this.cinecamera.m_Follow = newfollowtarget;
                this.cinecamera.m_LookAt = newlooktarget;

                cinecamera.m_Orbits[1].m_Radius = 7;
                cinecamera.m_Orbits[1].m_Height = 2;
                cinecamera.m_Orbits[2].m_Radius = 3;
                
            }
        
    }  

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            /*DriveUi.gameObject.SetActive(true);*/
            CAR_ENTER_UI.gameObject.SetActive(true);
            Candrive = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            DriveUi.gameObject.SetActive(false);
            CAR_ENTER_UI.gameObject.SetActive(false);
            Candrive = false;
        }
    }

}
