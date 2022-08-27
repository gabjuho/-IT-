using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWindowBack : MonoBehaviour
{
    public CanvasGroup ConfirmWindow;
    public CanvasGroup Lobby;
    public Image ConfirmWindowImage;
    public AudioClip Sound;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onBackBtn()
    {
        audiomanager.PlaySound(Sound);
        ConfirmWindowImage.color = new Color32(0, 0, 0, 0);
        Lobby.blocksRaycasts = true;
        Lobby.interactable = true;
        ConfirmWindow.alpha = 0;
        ConfirmWindow.blocksRaycasts = false;
        ConfirmWindow.interactable = false;

    }
}
