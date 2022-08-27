using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankUpNextBtn : MonoBehaviour
{
    public Animator UpArrow;
    public CanvasGroup RankUpWindow;
    public Button NextBtn;
    public AudioClip NextSound;
    public AudioSource BGMmanager;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void ExitRankUpWindow()
    {
        audiomanager.PlaySound(NextSound);
        BGMmanager.volume = 0.5f;
        UpArrow.SetBool("isUpArrow", false);
        RankUpWindow.alpha = 0;
        RankUpWindow.blocksRaycasts = false;
        RankUpWindow.interactable = false;
    }
}
