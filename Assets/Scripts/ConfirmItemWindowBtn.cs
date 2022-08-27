using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmItemWindowBtn : MonoBehaviour
{
    public CanvasGroup ItemCountWindow;
    public CanvasGroup GoldTwiceWindow;
    public AudioClip Sound;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onConfirmBtn()
    {
        audiomanager.PlaySound(Sound);
        ItemCountWindow.alpha = 0;
        ItemCountWindow.blocksRaycasts = false;
        ItemCountWindow.interactable = false;
        GoldTwiceWindow.alpha = 1;
        GoldTwiceWindow.blocksRaycasts = true;
        GoldTwiceWindow.interactable = true;
    }

    public void offGoldTwiceWindow()
    {
        audiomanager.PlaySound(Sound);
        GoldTwiceWindow.alpha = 0;
        GoldTwiceWindow.blocksRaycasts = false;
        GoldTwiceWindow.interactable = false;
        ItemCountWindow.alpha = 1;
        ItemCountWindow.blocksRaycasts = true;
        ItemCountWindow.interactable = true;
    }
}
