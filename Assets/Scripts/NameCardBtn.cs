using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameCardBtn : MonoBehaviour
{
    public Image FadeImage;
    public CanvasGroup NameCardWindow;
    public CanvasGroup GoldUIGroup;
    public CanvasGroup ProfileBackG;
    public Text BestWaveT;
    public Text BackPackT;
    public Text AttackT;
    public Text ItemTimeT;
    public Text HealItemCoolT;
    public Image Rank;
    public Image MaxRank;
    public Animator MaxRankAnime;
    public Image[] HeartGroup;
    public Sprite HalfHeart;
    public Sprite FullHeart;
    public Sprite Bronze;
    public Sprite Silver;
    public Sprite Gold;
    public Sprite Platinum;
    public Sprite Diamond;
    public AudioClip Sound;
    AudioManager audiomanager;
    int HeartLevel;
    int BestScore;
    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void OnNameCardWindow()
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        HeartLevel = PlayerPrefs.GetInt("HeartLevel", 0);
        audiomanager.PlaySound(Sound);
        if(BestScore < 5)
        {
            Rank.sprite = Bronze;
            ItemTimeT.text = "아이템 지속시간 + " + 0;
            HealItemCoolT.text = "힐 아이템 쿨타임 - " + 0;
        }
        else if(BestScore >= 5 && BestScore < 10)
        {
            Rank.sprite = Silver;
            ItemTimeT.text = "아이템 지속시간 + " + 3;
            HealItemCoolT.text = "힐 아이템 쿨타임 - " + 1;
        }
        else if(BestScore >= 10 && BestScore < 15)
        {
            Rank.sprite = Gold;
            ItemTimeT.text = "아이템 지속시간 + " + 8;
            HealItemCoolT.text = "힐 아이템 쿨타임 - " + 2;
        }
        else if(BestScore >= 15 && BestScore < 20)
        {
            Rank.sprite = Platinum;
            ItemTimeT.text = "아이템 지속시간 + " + 13;
            HealItemCoolT.text = "힐 아이템 쿨타임 - " + 3;
        }
        else if(BestScore >= 20 && BestScore < 25)
        {
            Rank.sprite = Diamond;
            ItemTimeT.text = "아이템 지속시간 + " + 18;
            HealItemCoolT.text = "힐 아이템 쿨타임 - " + 5;
        }
        else if(BestScore >= 25)
        {
            Rank.color = new Color32(255, 255, 255, 0);

            MaxRankAnime.SetBool("isMaxRank", true);
            ItemTimeT.text = "아이템 지속시간 + " + 30;
            HealItemCoolT.text = "힐 아이템 쿨타임 - " + 9;
        }
        if((HeartLevel + 1) % 2 == 0)
        {
            for(int i=0;i<(HeartLevel + 1) / 2;i++)
            {
                HeartGroup[i].sprite = FullHeart;
            }
        }
        else if(HeartLevel == 0)
        {
            HeartGroup[0].sprite = HalfHeart;
        }
        else
        {
            for (int i = 0; i < (HeartLevel + 1) / 2; i++)
            {
                HeartGroup[i].sprite = FullHeart;
            }
            HeartGroup[(HeartLevel + 1) / 2].sprite = HalfHeart;
        }
        BestWaveT.text = "최고 웨이브: " + PlayerPrefs.GetInt("BestScore", 0);
        BackPackT.text = "가방 공간: " + (PlayerPrefs.GetInt("ProtectLevel", 0) + 3);
        AttackT.text = "공격력: " + (PlayerPrefs.GetInt("AttackLevel", 0) + 1);
        FadeImage.color = new Color32(0, 0, 0, 180);
        FadeImage.raycastTarget = true;
        ProfileBackG.alpha = 0;
        ProfileBackG.interactable = false;
        ProfileBackG.blocksRaycasts = false;
        NameCardWindow.alpha = 1;
        NameCardWindow.blocksRaycasts = true;
        NameCardWindow.interactable = true;
        GoldUIGroup.alpha = 0;
        GoldUIGroup.blocksRaycasts = false;
    }
    public void BackNameCardWindow()
    {
        audiomanager.PlaySound(Sound);
        FadeImage.color = new Color32(0, 0, 0, 0);
        FadeImage.raycastTarget = false;
        NameCardWindow.alpha = 0;
        NameCardWindow.blocksRaycasts = false;
        NameCardWindow.interactable = false;
        GoldUIGroup.alpha = 1;
        GoldUIGroup.blocksRaycasts = true;
        ProfileBackG.alpha = 1;
        ProfileBackG.interactable = true;
        ProfileBackG.blocksRaycasts = true;
    }
}
