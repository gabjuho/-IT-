using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipNextBtn : MonoBehaviour
{
    public CanvasGroup[] Page;
    public Image[] ButtonImage;
    public int pageNum;
    public TipNextBtn tipnextbtn;
    public Button button;
    public AudioClip Sound;
    public Text Title;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onNextBtn()
    {
        audiomanager.PlaySound(Sound);
        if (pageNum == 0)
        {
            OffCanvas(Page[pageNum]);
            OnCanvas(Page[pageNum + 1]);
            ButtonImage[1].color = new Color32(255, 255, 255, 255);
            button.interactable = true;
            ++pageNum;
            Title.text = "2. 랭크";
        }
        else if(pageNum == 1)
        {
            OffCanvas(Page[pageNum]);
            OnCanvas(Page[pageNum + 1]);
            ++pageNum;
            gameObject.GetComponent<Button>().interactable = false;
            ButtonImage[0].color = new Color32(255, 255, 255, 0);
            Title.text = "3. 랭크효과";
        }
    }
    public void onBackBtn()
    {
        audiomanager.PlaySound(Sound);
        if (tipnextbtn.pageNum == 1)
        {
            OffCanvas(Page[tipnextbtn.pageNum]);
            OnCanvas(Page[tipnextbtn.pageNum - 1]);
            gameObject.GetComponent<Button>().interactable = false;
            ButtonImage[1].color = new Color32(255, 255, 255, 0);
            --tipnextbtn.pageNum;
            Title.text = "1. 시간에 따른 변화";
        }
        else if(tipnextbtn.pageNum == 2)
        {
            OffCanvas(Page[tipnextbtn.pageNum]);
            OnCanvas(Page[tipnextbtn.pageNum - 1]);
            ButtonImage[0].color = new Color32(255, 255, 255, 255);
            button.interactable = true;
            --tipnextbtn.pageNum;
            Title.text = "2. 랭크";
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
