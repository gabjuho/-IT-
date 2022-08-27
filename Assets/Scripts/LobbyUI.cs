using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

 public enum BtnType2
{
    Play,
    Profile,
    Shop,
    Back1,
    Back2,
    Plus_Heart,
    Plus_Protect,
    Plus_Attack
}
public class LobbyUI : MonoBehaviour
{
    //알파값으로 조정하는 창들
    public CanvasGroup Lobby;
    public CanvasGroup Profile;
    public CanvasGroup Shop;
    public CanvasGroup PlayConfirm;
    public CanvasGroup SeeWindowBtn;
    //버튼 타입
    public BtnType2 currentType;
    //능력치 레벨 표시하는 텍스트
    public TextMeshProUGUI HeartText;
    public TextMeshProUGUI ProtectText;
    public TextMeshProUGUI AttackText;
    //능력치 레벨
    public int HeartLevel = 0;
    public int ProtectLevel = 0;
    public int AttackLevel = 0;
    //능력치 구매 가격 표시하는 텍스트
    public TextMeshProUGUI HeartPriceText;
    public TextMeshProUGUI ProtectPriceText;
    public TextMeshProUGUI AttackPriceText;
    //능력치 구매 가격
    public int HeartPrice = 100;
    public int ProtectPrice = 100;
    public int AttackPrice = 300;
    //소유 골드 표시하는 텍스트
    public TextMeshProUGUI GoldText;
    //골드 계산기 클래스 변수
    GoldManager goldmanager;
    //만렙달성시 없앨 가격 텍스트
    public TextMeshProUGUI HText;
    public TextMeshProUGUI PText;
    public TextMeshProUGUI AText;
    //만렙달성시 없앨 골드 이미지들
    public Image HImage;
    public Image PImage;
    public Image AImage;
    //Keystring
    private string key1 = "HeartLevel";
    private string key2 = "ProtectLevel";
    private string key3 = "AttackLevel";
    private string key4 = "HeartPrice";
    private string key5 = "ProtectPrice";
    private string key6 = "AttackPrice";
    private string key7 = "Gold";
    //
    public Image PlayConfirmBack;
    public TextMeshProUGUI HMax;
    public TextMeshProUGUI PMax;
    public TextMeshProUGUI AMax;
    public CanvasGroup GoldBar;
    public AudioClip Sound;
    public AudioManager audiomanager;
    public Image LobbyImage;
    public AudioSource BGMmanager;
    public Image GoldImage;

    public void Awake()
    {
        goldmanager = GameObject.Find("GoldManager").GetComponent<GoldManager>();
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        HeartLevel = PlayerPrefs.GetInt(key1, 0);
        ProtectLevel = PlayerPrefs.GetInt(key2, 0);
        AttackLevel = PlayerPrefs.GetInt(key3, 0);
        HeartPrice = PlayerPrefs.GetInt(key4, 100);
        ProtectPrice = PlayerPrefs.GetInt(key5, 100);
        AttackPrice = PlayerPrefs.GetInt(key6, 300);
        LevelChangeText(HeartText, HeartLevel);
        LevelChangeText(ProtectText, ProtectLevel);
        LevelChangeText(AttackText, AttackLevel);
        ChangePrice(HeartPriceText, HeartPrice);
        ChangePrice(ProtectPriceText, ProtectPrice);
        ChangePrice(AttackPriceText, AttackPrice);
        goldmanager.Gold = PlayerPrefs.GetInt(key7, 0);
        GoldChangeText(GoldText, goldmanager.Gold);
        if(gameObject.name == "Heart_Button" && HeartLevel == 7)
        {
            HeartPriceText.color = new Color32(255, 255, 255, 0);
            GoldImage.color = new Color32(255, 255, 255, 0);
        }
        if(gameObject.name == "Protect_Button" && ProtectLevel == 5)
        {
            ProtectPriceText.color = new Color32(255, 255, 255, 0);
            GoldImage.color = new Color32(255, 255, 255, 0);
        }
        if(gameObject.name == "Attack_Button" && AttackLevel == 4)
        {
            AttackPriceText.color = new Color32(255, 255, 255, 0);
            GoldImage.color = new Color32(255, 255, 255, 0);
        }
    }
    public void Update()
    {
        if(HeartLevel == 10)
        {
            HText.color = new Color(255, 255, 255, 0);
            HImage.color = new Color(255, 255, 255, 0);
        }
        if(ProtectLevel == 10)
        {
            PText.color = new Color(255, 255, 255, 0);
            PImage.color = new Color(255, 255, 255, 0);
        }
        if(AttackLevel == 10)
        {
            AText.color = new Color(255, 255, 255, 0);
            AImage.color = new Color(255, 255, 255, 0);
        }
    }
    public void onBtnclick()
    {
        switch(currentType)
        {
            case BtnType2.Play:
                Lobby.blocksRaycasts = false;
                Lobby.interactable = false;
                PlayConfirmBack.color = new Color32(0, 0, 0, 100);
                CanvasOn(PlayConfirm);
                audiomanager.PlaySound(Sound);
                Debug.Log("게임시작");
                break;
            case BtnType2.Profile:
                CanvasOff(Lobby);
                CanvasOn(Profile);
                audiomanager.PlaySound(Sound);
                break;
            case BtnType2.Shop:
                LobbyImage.color = new Color32(255, 255, 255, 0);
                LobbyImage.raycastTarget = false;
                CanvasOff(SeeWindowBtn);
                CanvasOff(Lobby);
                CanvasOn(Shop);
                CanvasOff(GoldBar);
                audiomanager.PlaySound(Sound);
                if (PlayerPrefs.GetInt("volume", 0) == 0)
                {
                    BGMmanager.volume = 0.2f;
                }
                break;
            case BtnType2.Back1:
                audiomanager.PlaySound(Sound);
                SceneManager.LoadScene("Main");
                Debug.Log("메인화면으로");
                break;
            case BtnType2.Back2:
                audiomanager.PlaySound(Sound);
                CanvasOff(Profile);
                CanvasOn(Lobby);
                break;
            case BtnType2.Plus_Heart:
                if(HeartLevel == 7)
                {
                    HMax.color = new Color32(255, 255, 255, 255);
                }
                else if(goldmanager.Gold >= HeartPrice)
                {
                    audiomanager.PlaySound(Sound);
                    HeartLevel++;
                    goldmanager.Gold -= HeartPrice;
                    HeartPrice += 200 * HeartLevel;
                    ChangePrice(HeartPriceText, HeartPrice);
                    GoldChangeText(GoldText, goldmanager.Gold);
                    LevelChangeText(HeartText, HeartLevel);
                    PlayerPrefs.SetInt(key1, HeartLevel);
                    PlayerPrefs.SetInt(key4, HeartPrice);
                    PlayerPrefs.SetInt(key7, goldmanager.Gold);
                    if (HeartLevel == 7)
                    {
                        HMax.color = new Color32(255, 255, 255, 255);
                        HeartPriceText.color = new Color32(255, 255, 255, 0);
                        GoldImage.color = new Color32(255, 255, 255, 0);
                    }
                }
                else if(goldmanager.Gold < HeartPrice)
                {
                    
                }
                break;
            case BtnType2.Plus_Protect:
                if (ProtectLevel == 5)
                {
                    PMax.color = new Color32(255, 255, 255, 255);
                }
                else if(goldmanager.Gold >= ProtectPrice)
                {
                    audiomanager.PlaySound(Sound);
                    ++ProtectLevel;
                    goldmanager.Gold -= ProtectPrice;
                    ProtectPrice += 300 * ProtectLevel;
                    ChangePrice(ProtectPriceText, ProtectPrice);
                    GoldChangeText(GoldText, goldmanager.Gold);
                    LevelChangeText(ProtectText, ProtectLevel);
                    PlayerPrefs.SetInt(key2, ProtectLevel);
                    PlayerPrefs.SetInt(key5, ProtectPrice);
                    PlayerPrefs.SetInt(key7, goldmanager.Gold);
                    if (ProtectLevel == 5)
                    {
                        PMax.color = new Color32(255, 255, 255, 255);
                        ProtectPriceText.color = new Color32(255, 255, 255, 0);
                        GoldImage.color = new Color32(255, 255, 255, 0);
                    }
                    GameObject.Find("MyItemResetManager").GetComponent<MyItemReset>().ChangeMaxItem();
                }
                else if(goldmanager.Gold < ProtectPrice)
                {
                    
                }
                break;
            case BtnType2.Plus_Attack:
                if(AttackLevel == 4)
                {
                    AMax.color = new Color32(255, 255, 255, 255);
                    Debug.Log("만렙입니다.");
                }
                else if (goldmanager.Gold >= AttackPrice)
                {
                    audiomanager.PlaySound(Sound);
                    AttackLevel++;
                    goldmanager.Gold -= AttackPrice;
                    AttackPrice += 500 * AttackLevel;
                    ChangePrice(AttackPriceText, AttackPrice);
                    GoldChangeText(GoldText, goldmanager.Gold);
                    LevelChangeText(AttackText, AttackLevel);
                    PlayerPrefs.SetInt(key3, AttackLevel);
                    PlayerPrefs.SetInt(key6, AttackPrice);
                    PlayerPrefs.SetInt(key7, goldmanager.Gold);
                    if (AttackLevel == 4)
                    {
                        AMax.color = new Color32(255, 255, 255, 255);
                        AttackPriceText.color = new Color32(255, 255, 255, 0);
                        GoldImage.color = new Color32(255, 255, 255, 0);
                    }
                }
                else if(goldmanager.Gold < AttackPrice)
                {
                    
                }
                break;
        }
    }

    public void CanvasOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;
    }
    public void CanvasOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }

    public void LevelChangeText(TextMeshProUGUI temp,int level)
    {
        temp.text = level.ToString();
    }

    public void GoldChangeText(TextMeshProUGUI temp,int gold)
    {
        temp.text = gold.ToString();
    }
    public void ChangePrice(TextMeshProUGUI temp,int price)
    {
        temp.text = price.ToString();
    }


    //데이터 베이스에 저장해야할 값
    //체력 가격, 방어력 가격, 공격력 가격
    //현재 보유 골드, 능력치의 레벨들
    //능력치 레벨과 능력치 가격을 공식화 시켜서 가격을 결정하면 능력치 가격을 따로 데이터 베이스에 저장할 필요는 없다.
}
