using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ExitBtnType
{
    Yes,
    Cancel
}
public class ExitGame : MonoBehaviour
{
    public CanvasGroup SubMenuWindow;
    public CanvasGroup ExitConfirmWindow;
    public ExitBtnType currentType;
    public AudioClip Sound;
    AudioManager UISoundmanager;
    private void Awake()
    {
        UISoundmanager = GameObject.Find("UISoundManager").GetComponent<AudioManager>();
    }

    public void onExitBtn()
    {
        switch(currentType)
        {
            case ExitBtnType.Yes:
                UISoundmanager.PlaySound(Sound);
                Time.timeScale = 1;
                SceneManager.LoadScene("Loading2");
                break;
            case ExitBtnType.Cancel:
                UISoundmanager.PlaySound(Sound);
                ExitConfirmWindow.alpha = 0;
                ExitConfirmWindow.interactable = false;
                ExitConfirmWindow.blocksRaycasts = false;
                SubMenuWindow.alpha = 1;
                SubMenuWindow.interactable = true;
                SubMenuWindow.blocksRaycasts = true;
                break;
        }
    }
}
