using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Targetforplayer : MonoBehaviour
{
    
    // declear the variable
    [SerializeField]
    private Vector3 SpinAmount = new Vector3(0, 20, 0);

    // this will rotate the target object to visible for player
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (SpinAmount * Time.deltaTime));
    }

    // This function will destroy the target after player touch the target
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);       
    }
}
