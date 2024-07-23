using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_BG_SOUND : MonoBehaviour
{

    private AudioSource Game_bg_sound;
    // Start is called before the first frame update
    void Start()
    {
        Game_bg_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Game_bg_sound.Play();  
    }
}
