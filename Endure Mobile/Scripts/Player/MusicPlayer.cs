using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public GameObject player;

    public float timeToStop = 3.0f;

    public AudioClip fightMusicSFX;
    public AudioClip sneakMusicSFX;
    public AudioClip idleMusicSFX;

    public bool sneakMode = false; 
    public bool fightMode = false;
    public bool idleMode  = false;
    
    public bool FightModeLoop = false;

    public AudioSource source;

    private float sound_volume;

    

    // Start is called before the first frame update
    void Start()
    {
        source = player.GetComponent<AudioSource>();
        sound_volume = source.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(fightMode && !source.isPlaying)
        {
            source.PlayOneShot(fightMusicSFX);
            fightMode = false;
        }
        if(idleMode && !source.isPlaying)
        {
            source.volume = sound_volume;
            source.PlayOneShot(idleMusicSFX);
            idleMode  = false;
            sneakMode = false;
            fightMode = false;
        }
    }


    public void setFightMusic(bool s_mode)
    {
        fightMode = s_mode;
    }

    public void setSneakMusic(bool s_mode)
    {
        sneakMode = s_mode;
    }

    public void setIdleMusic(bool s_mode)
    {
        idleMode = s_mode;
    }
}
