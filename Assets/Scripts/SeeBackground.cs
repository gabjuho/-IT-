using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeBackground : MonoBehaviour
{
    public CanvasGroup LobbyUI;
    public Text BtnText;
    public bool isOn;
    public AudioClip Sound;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onSeeBackBtn()
    {
        if (isOn == false)
        {
            audiomanager.PlaySound(Sound);
            isOn = true;
            LobbyUI.alpha = 0;
            LobbyUI.blocksRaycasts = false;
            LobbyUI.interactable = false;
            BtnText.text = "Off";
        }
        else
        {
            audiomanager.PlaySound(Sound);
            isOn = false;
            LobbyUI.alpha = 1;
            LobbyUI.blocksRaycasts = true;
            LobbyUI.interactable = true;
            BtnText.text = "On";
        }
    }
}
