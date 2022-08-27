using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public CanvasGroup Ingame;
    public CanvasGroup Sub;
    public Image IngameImage;
    public AudioClip UISound;
    AudioManager UISoundmanager;
    private void Awake()
    {
        UISoundmanager = GameObject.Find("UISoundManager").GetComponent<AudioManager>();
    }
    public void OnPauseButton()
    {
        UISoundmanager.PlaySound(UISound);
        Time.timeScale = 0;
        Ingame.blocksRaycasts = false;
        Ingame.interactable = false;
        IngameImage.color = new Color32(0, 0, 0, 100);
        Sub.blocksRaycasts = true;
        Sub.interactable = true;
        Sub.alpha = 1;
    }
}
