using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankAbilityBtn : MonoBehaviour
{
    public CanvasGroup RankAbilityWindow;
    public bool isOnWindow;
    public AudioClip Sound;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onRankAbilityWindow()
    {
        audiomanager.PlaySound(Sound);
        if (isOnWindow == false)
        {
            RankAbilityWindow.alpha = 1;
            isOnWindow = true;
        }
        else
        {
            RankAbilityWindow.alpha = 0;
            isOnWindow = false;
        }
        
    }
}
