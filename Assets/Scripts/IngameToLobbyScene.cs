using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameToLobbyScene : MonoBehaviour
{
    public AudioClip NextSound;
    AudioManager UISoundmanager;
    private void Awake()
    {
        UISoundmanager = GameObject.Find("UISoundManager").GetComponent<AudioManager>();
    }
    public void GoLobby()
    {
        UISoundmanager.PlaySound(NextSound);
        SceneManager.LoadScene("Loading2");
    }
}
