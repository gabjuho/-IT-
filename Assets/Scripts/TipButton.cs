using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipButtonType
{
    Tip,
    Back
}
public class TipButton : MonoBehaviour
{
    public TipButtonType currentType;
    public CanvasGroup LobbyWindow;
    public CanvasGroup TipWindow;
    public CanvasGroup[] Page;
    public Image TipWindowImage;
    public AudioClip Sound;
    public TipNextBtn tipnextClass;
    public Button NextBtn;
    public Button BackBtn;
    public Image NextBtnImage;
    public Image BackBtnImage;
    public Animator MasterAni;
    public Text Title;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        MasterAni.SetBool("isMaxRank", true);
    }

    public void onTipBtn()
    {
        switch(currentType)
        {
            case TipButtonType.Tip:
                audiomanager.PlaySound(Sound);
                LobbyWindow.blocksRaycasts = false;
                LobbyWindow.interactable = false;
                TipWindow.alpha = 1;
                TipWindow.interactable = true;
                TipWindow.blocksRaycasts = true;
                TipWindowImage.color = new Color32(0, 0, 0, 180);
                Title.text = "1. 시간에 따른 변화";
                break;
            case TipButtonType.Back:
                audiomanager.PlaySound(Sound);
                TipWindow.alpha = 0;
                TipWindow.interactable = false;
                TipWindowImage.color = new Color32(0, 0, 0, 0);
                TipWindow.blocksRaycasts = false;
                LobbyWindow.blocksRaycasts = true;
                LobbyWindow.interactable = true;
                tipnextClass.pageNum = 0;
                OnCanvas(Page[0]);
                OffCanvas(Page[1]);
                OffCanvas(Page[2]);
                NextBtn.interactable = true;
                NextBtnImage.color = new Color32(255, 255, 255, 255);
                BackBtn.interactable = false;
                BackBtnImage.color = new Color32(255, 255, 255, 0);
                break;
        }
    }
    void OnCanvas(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    void OffCanvas(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
