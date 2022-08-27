using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BtnType3
{
    Back,
    Item,
    WindowBack
}
public class ShopBtn : MonoBehaviour
{
    public BtnType3 currentType;
    public CanvasGroup Shop;
    public CanvasGroup Lobby;
    public CanvasGroup BuyWindow;
    public CanvasGroup GoldBar;
    public Image Item;
    public Sprite ChangeImage;
    public string ItemExplainChange;
    public Text ItemExplain;
    public TextMeshProUGUI ItemPriceText;
    public int ItemPrice;
    public AudioClip Sound;
    public Image LobbyImage;
    public AudioSource BGMmanager;
    public CanvasGroup SeeWindowBtn;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void OnBtnClick()
    {
        switch(currentType)
        {
            case BtnType3.Back:
                CanvasOn(SeeWindowBtn);
                if (PlayerPrefs.GetInt("volume", 0) == 0)
                {
                    BGMmanager.volume = 0.5f;
                }
                audiomanager.PlaySound(Sound);
                LobbyImage.color = new Color32(255, 255, 255, 255);
                LobbyImage.raycastTarget = true;
                CanvasOff(Shop);
                CanvasOn(Lobby);
                CanvasOn(GoldBar);
                break;
            case BtnType3.Item:
                audiomanager.PlaySound(Sound);
                Shop.alpha = 0.5f;
                Shop.blocksRaycasts = false;
                Shop.interactable = false;
                CanvasOn(BuyWindow);
                CanvasOn(GoldBar);
                Item.sprite = ChangeImage;
                ItemExplain.text = ItemExplainChange;
                ItemPriceText.text = ItemPrice.ToString();
                break;
            case BtnType3.WindowBack:
                audiomanager.PlaySound(Sound);
                CanvasOff(BuyWindow);
                CanvasOff(GoldBar);
                Shop.alpha = 1;
                Shop.blocksRaycasts = true;
                Shop.interactable = true;
                break;
        }
    }

    private void CanvasOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }
    private void CanvasOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;
    }
}
