using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcreation : MonoBehaviour
{
    // declearation of variables for bullet,position and aim
    public GameObject bullet;
    public Transform barrelpos;
    public Transform aimpos;

    // decleration of float for bullet velocity
    [SerializeField] float bulletvelocity = 500;

    // decleration of gunshot audioclip
    [SerializeField] AudioClip gunshot;
    AudioSource audioSource;
    // Start is called before the first frame update
    // in start function we get the audio source
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // in shoot function we play the gun sound also look to the aim position 
    public void Shoot()
    {
        audioSource.PlayOneShot(gunshot);
        barrelpos.LookAt(aimpos);
        GameObject currentbullet = Instantiate(bullet, barrelpos.position, barrelpos.rotation);
        Rigidbody rb = currentbullet.GetComponent<Rigidbody>();
        // then we get the bullet body and add force to it
        rb.AddForce(barrelpos.forward * bulletvelocity,ForceMode.Impulse);

    }
}
