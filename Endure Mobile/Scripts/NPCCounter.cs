using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCounter : MonoBehaviour
{

    public GameObject player;
    public int npc_amount;
    private MusicPlayer music_player;
    public bool allDead = false;
    public int destructTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        music_player = player.GetComponent<MusicPlayer>();
        npc_amount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(npc_amount == 0 && allDead) // fade audio out if everyone's dead. 
        {
            MusicController.FadeOut(music_player, music_player.source, 10.0f); // fade audio out.
            allDead = false;
            //StartCoroutine(destruct());
        }
    }

    public void setAllDead(bool ad)
    {
        allDead = ad;
    }

    IEnumerator destruct()
    {
        yield return new WaitForSeconds(destructTime);
        Destroy(this.gameObject);
    }
}
