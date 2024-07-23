using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class Pathfindingplayer : MonoBehaviour
{
    // declearation of variable for target,player,path,path update speed
    [SerializeField]
    private Targetforplayer Prefab;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private LineRenderer Path;
    [SerializeField]
    private float PathHeightOffset = 0.5f;
    [SerializeField]
    private float SpawnHeightOffset = 2f;
    [SerializeField]
    private float PathUpdateSpeed = 0.06f;

    // mini button on minimap to access the list of department
    public GameObject target;
    public GameObject MINI_MAP_BTN;

    private Targetforplayer ActiveInstance;
    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;

    private void Awake()
    {
        Triangulation = NavMesh.CalculateTriangulation();
    }

    // function to activate the mini map
    public void MINI_MAPE()
    {
        MINI_MAP_BTN.SetActive(true);
    }
    // function to deactivate the mini map
    public void BACK_BTN()
    {
        MINI_MAP_BTN.SetActive(false);
    }
    /*function for each target to find that target to draw path
    these function will find the target and then call the function 
    to draw the path between plare and target*/
    public void HELEPAD()
    {
        target = GameObject.Find("HELEPAD");
        if (target != null)
        {
            Instansiator();
        }
    }
   
    public void MAIN_BLOCK()
    {
        target = GameObject.Find("MIANBLOCK");
        if(target != null )
        {
            Instansiator();
        }
    }

    public void ADMIN()
    {
        target = GameObject.Find("ADMIN");
        if (target != null)
        {
            Instansiator();
        }
    }
    
    public void CONVOCATION_HALL()
    {
        target = GameObject.Find("convocation hall and law");
        if (target != null)
        {
            Instansiator();
        }
    }
    public void DIGITAL_LAB()
    {
        target = GameObject.Find("digital_lab");
        if (target != null)
        {
            Instansiator();
        }
    }
    public void ECOMREC()
    {
        target = GameObject.Find("e_commrec");
        if (target != null)
        {
            Instansiator();
        }
    }

    public void BANK()
    {
        target = GameObject.Find("bank");
        if (target != null)
        {
            Instansiator();
        }

    }
    public void EXAMINATION_CENTER()
    {
        target = GameObject.Find("examination_center");
        if (target != null)
        {
            Instansiator();
        }

    }
    public void ARTS_BLOCK()
    {
        target = GameObject.Find("artsblock");
        if (target != null)
        {
            Instansiator();
        }
    }
    public void GROUND()
    {
        target = GameObject.Find("ground");
        if (target != null)
        {
            Instansiator();
        }
    }
    public void GATE_1()
    {
        target = GameObject.Find("gate_1");
        if (target != null)
        {
            Instansiator();
        }

    }
    public void GATE_2()
    {
        target = GameObject.Find("gate_2");
        if (target != null)
        {
            Instansiator();
        }

    }
    public void GATE_3()
    {
        target = GameObject.Find("gate_3");
        if (target != null)
        {
            Instansiator();
        }
    }
    public void GATE_4()
    {
        target = GameObject.Find("gate_4");
        if (target != null)
        {
            Instansiator();
        }

    }

    public void PHOTO_STATE_CABIN()
    {
        target = GameObject.Find("photostate cabin");
        if (target != null)
        {
            Instansiator();
        }

    }

    public void JAWAN_EDUCATION()
    {
        target = GameObject.Find("jawan_education");
        if (target != null)
        {
            Instansiator();
        }

    }

    public void HELATH_CENTER()
    {
        target = GameObject.Find("helath center");
        if (target != null)
        {
            Instansiator();
        }
    } public void Bus_stand()
    {
        target = GameObject.Find("Bus_stand");
        if (target != null)
        {
            Instansiator();
        }
    }

    public void MASQU_PHYSICS_RESEARCH_CENTER()
    {
        target = GameObject.Find("physics_resaech AND maque");
        if (target != null)
        {
            Instansiator();
        }

    }

    public void CAFE()
    {
        target = GameObject.Find("cafe");
        if (target != null)
        {
            Instansiator();
        }

    }

    public void LIBRARY()
    {
        target = GameObject.Find("library");
        if (target != null)
        {
            Instansiator();
        }

    }

    public void SPORT_CENTER()
    {
        target = GameObject.Find("sport_center");
        if (target != null)
        {
            Instansiator();
        }


    }
    public void Urdu()
    {
        target = GameObject.Find("URDU");
        if (target != null)
        {
            Instansiator();
        }


    }
    public void Cafe()
    {
        target = GameObject.Find("cafe");
        if (target != null)
        {
            Instansiator();
        }


    }
    public void Chemistry()
    {
        target = GameObject.Find("chemisrty");
        if (target != null)
        {
            Instansiator();
        }


    }

    public void Car_parking()
    {
        target = GameObject.Find("car parking");
        if (target != null)
        {
            Instansiator();
        }


    }
    public void HostelMALAKAMHMAD()
    {
        target = GameObject.Find("hostel_MALAK_AHMAD");
        if (target != null)
        {
            Instansiator();
        }


    }
    public void HOSTELFAUJI()
    {
        target = GameObject.Find("hostel_fauji");
        if (target != null)
        {
            Instansiator();
        }


    }

    // this function is instansiate the object as a target and
    // call if the condition is true DrawPathToCollectable to draw path
    public void Instansiator()
    {
        Instantiate(Prefab, target.transform.position, target.transform.rotation);

        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }

        DrawPathCoroutine = StartCoroutine(DrawPathToCollectable());
        MINI_MAP_BTN.SetActive(false);

    }

    // this function is draw path between the player and target
    public IEnumerator DrawPathToCollectable()
    {
        WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        while (target != null)
        {
            if (NavMesh.CalculatePath(Player.position, target.transform.position, NavMesh.AllAreas, path))
            {
                Path.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
                }
            }
            else
            {
                Debug.LogError($"Unable to calculate a path on the NavMesh between {Player.position} and {ActiveInstance.transform.position}!");
            }

            yield return Wait;
        }
    }

}
