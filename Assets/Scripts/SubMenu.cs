using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SubMenuBtn
{
    Continue,
    Quit
}
public class SubMenu : MonoBehaviour
{
    public SubMenuBtn currentType;
    public CanvasGroup Sub;
    public CanvasGroup Ingame;
    public CanvasGroup ExitConfirmWindow;
    public Image IngameImage;
    public AudioClip UISound;
    AudioManager UISoundmanager;
    private void Awake()
    {
        UISoundmanager = GameObject.Find("UISoundManager").GetComponent<AudioManager>();
    }
    public void OnBtnClick()
    {
        switch(currentType)
        {
            case SubMenuBtn.Continue:
                UISoundmanager.PlaySound(UISound);
                Sub.alpha = 0;
                Sub.blocksRaycasts = false;
                Sub.interactable = false;
                Ingame.blocksRaycasts = true;
                Ingame.interactable = true;
                IngameImage.color = new Color32(0, 0, 0, 0);
                Time.timeScale = 1;
                break;
            case SubMenuBtn.Quit:
                UISoundmanager.PlaySound(UISound);
                ExitConfirmWindow.alpha = 1;
                ExitConfirmWindow.interactable = true;
                ExitConfirmWindow.blocksRaycasts = true;
                Sub.alpha = 0;
                Sub.blocksRaycasts = false;
                Sub.interactable = false;
                break;
        }
    }
}
