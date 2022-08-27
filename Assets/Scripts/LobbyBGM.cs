using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBGM : MonoBehaviour
{
    private AudioSource BGMmanager;
    bool isplaying;
    private void Start()
    {
        BGMmanager = GetComponent<AudioSource>();
        isplaying = true;
    }

    private void Update()
    {
        if (BGMmanager.isPlaying == false && isplaying == true)
        {
            isplaying = false;
            StartCoroutine(Replay());
        }
    }

    IEnumerator Replay()
    {
        yield return null;
        yield return new WaitForSeconds(10f);
        BGMmanager.Play();
        isplaying = true;
    }



}
