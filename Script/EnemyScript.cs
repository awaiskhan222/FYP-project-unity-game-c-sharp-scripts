using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    // get the navmesh of the enemy
    NavMeshAgent enemy;

    // declear the player as a terget for enemy
    public Transform target;

    // get the aniamtor of the enemy
    private Animator anim_enemy;

    // get the audio source of the enemy
    private AudioSource audioSource;
    // Start is called before the first frame update

    // declear the variable to access it
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        anim_enemy = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
    }

    // Update is called once per frame

    // the function will check the condition and then the enemy follow the target
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < 20)
        {
            enemy.SetDestination(target.position);
            anim_enemy.SetBool("zoombie_walk", true);
            audioSource.enabled = true;
            
            
        }

        else
        {
            audioSource.enabled = false;
        }

       
    }
    // this function will call of the bullet is collide with the enemy
    private void OnCollisionEnter(Collision collision)
    {
        enemy.enabled = false;
        anim_enemy.SetTrigger("zoombiedying");
        Invoke("Destroy", 5f);
        

    }

    // This functio detroy the game object
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
