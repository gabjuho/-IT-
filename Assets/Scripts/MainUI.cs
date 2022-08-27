using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BtnType
{
    Start,
    Quit
}
public class MainUI : MonoBehaviour
{
    public BtnType btn;
    public AudioClip Sound;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void OnBtnClick()
    {
        switch(btn)
        {
            case BtnType.Start:
                audiomanager.PlaySound(Sound);
                Invoke("GoLobby", 0.3f);
                break;
            case BtnType.Quit:
                audiomanager.PlaySound(Sound);
                Application.Quit();
                Debug.Log("나감");
                break;
        }
    }
    void GoLobby()
    {
        SceneManager.LoadScene("Loading");
    }
}
