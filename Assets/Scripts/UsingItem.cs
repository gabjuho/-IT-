using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Night,
    Shield,
    Heal
}
public class UsingItem : MonoBehaviour
{
    public ItemType itemtype;
    public int HealC;
    public int NightC;
    public int ShieldC;
    private int HealCool;
    private int NightCool;
    private int ShieldCool;
    private int NightPotionTime;
    private int ShieldTime;
    public bool isItemTimeEnd;
    public bool isItemCoolEnd;
    public Text Counttext;
    public Text CoolTimeT;
    public Text NPLastTime;
    public Image CoolTimeImage;
    public Button ItemBtn;
    public Animator HealAnime;
    public Animator ShieldCount;
    public Animator NightPotion;
    public Animator NightGGamBBak;
    public GameObject ShieldObject;
    public Text ShieldCountT;
    public AudioClip ItemSound;
    Player player;
    AudioManager UISoundmanager;
    
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        UISoundmanager = GameObject.Find("UISoundManager").GetComponent<AudioManager>();
        if (PlayerPrefs.GetInt("BestScore",0) < 5)
        {
            NightPotionTime = 6;
            ShieldTime = 5;
            HealCool = 10;
        }
        else if(PlayerPrefs.GetInt("BestScore", 0) >= 5 && PlayerPrefs.GetInt("BestScore", 0) < 10)
        {
            NightPotionTime = 9;
            ShieldTime = 8;
            HealCool = 9;
        }
        else if (PlayerPrefs.GetInt("BestScore", 0) >= 10 && PlayerPrefs.GetInt("BestScore", 0) < 15)
        {
            NightPotionTime = 14;
            ShieldTime = 13;
            HealCool = 8;
        }
        else if (PlayerPrefs.GetInt("BestScore", 0) >= 15 && PlayerPrefs.GetInt("BestScore", 0) < 20)
        {
            NightPotionTime = 19;
            ShieldTime = 18;
            HealCool = 7;
        }
        else if (PlayerPrefs.GetInt("BestScore", 0) >= 20 && PlayerPrefs.GetInt("BestScore", 0) < 25)
        {
            NightPotionTime = 24;
            ShieldTime = 23;
            HealCool = 5;
        }
        else if (PlayerPrefs.GetInt("BestScore", 0) >= 25)
        {
            NightPotionTime = 36;
            ShieldTime = 35;
            HealCool = 1;
        }
        NightCool = 15;
        ShieldCool = 20;
        HealC = PlayerPrefs.GetInt("HealB");
        NightC = PlayerPrefs.GetInt("NightB");
        ShieldC = PlayerPrefs.GetInt("ShieldB");
        if(itemtype == ItemType.Heal)
        {
            Counttext.text = "x" + HealC;
            if(HealC == 0)
            {
                ItemBtn.interactable = false;
                CoolTimeT.fontSize = 225;
                CoolTimeT.text = "None";
                CoolTimeT.color = new Color32(255, 255, 255, 255);
                CoolTimeT.raycastTarget = true;
                CoolTimeImage.color = new Color32(0, 0, 0, 150);
                CoolTimeImage.raycastTarget = true;
            }
        }
        else if (itemtype == ItemType.Night)
        {
            Counttext.text = "x" + NightC;
            if(NightC == 0)
            {
                ItemBtn.interactable = false;
                CoolTimeT.fontSize = 225;
                CoolTimeT.text = "None";
                CoolTimeT.color = new Color32(255, 255, 255, 255);
                CoolTimeT.raycastTarget = true;
                CoolTimeImage.color = new Color32(0, 0, 0, 150);
                CoolTimeImage.raycastTarget = true;
            }
        }
        else if (itemtype == ItemType.Shield)
        {
            Counttext.text = "x" + ShieldC;
            if(ShieldC == 0)
            {
                ItemBtn.interactable = false;
                CoolTimeT.fontSize = 225;
                CoolTimeT.text = "None";
                CoolTimeT.color = new Color32(255, 255, 255, 255);
                CoolTimeT.raycastTarget = true;
                CoolTimeImage.color = new Color32(0, 0, 0, 150);
                CoolTimeImage.raycastTarget = true;
            }
        }
    }
    private void Update()
    {
        
    }
    public void usingItem()
    {
        switch(itemtype)
        {
            case ItemType.Night:
                if(NightC != 0 && (GameObject.Find("GameManager").GetComponent<GameManager>().Wave + 1) % 5 == 0)
                {
                    UISoundmanager.PlaySound(ItemSound);
                    --NightC;
                    Counttext.text = "x" + NightC;
                    CoolTimeImage.color = new Color32(0, 0, 0, 150);
                    CoolTimeImage.raycastTarget = true;
                    ItemBtn.interactable = false;
                    CoolTimeT.color = new Color32(255, 255, 255, 255);
                    CoolTimeT.raycastTarget = true;
                    NightPotion.SetBool("UseNight", true);
                    StartCoroutine(NightPotionEffect());

                    if (NightC != 0)
                    {
                        StartCoroutine(CoolTimeCounting(NightCool));
                    }
                    else
                    {
                        CoolTimeImage.color = new Color32(0, 0, 0, 150);
                        CoolTimeImage.raycastTarget = true;
                        ItemBtn.interactable = false;
                        CoolTimeT.fontSize = 225;
                        CoolTimeT.text = "None";
                    }
                }
                break;
            case ItemType.Shield:
                if (ShieldC != 0)
                {
                    UISoundmanager.PlaySound(ItemSound);
                    --ShieldC;
                    Counttext.text = "x" + ShieldC;
                    CoolTimeImage.color = new Color32(0, 0, 0, 150);
                    CoolTimeImage.raycastTarget = true;
                    ItemBtn.interactable = false;
                    CoolTimeT.color = new Color32(255, 255, 255, 255);
                    CoolTimeT.raycastTarget = true;
                    Instantiate(ShieldObject);
                    ShieldCount.SetBool("UseShield", true);
                    StartCoroutine(ShieldCounting());
                    if(ShieldC != 0)
                    {
                        StartCoroutine(CoolTimeCounting(ShieldCool));
                    }
                    else
                    {
                        CoolTimeImage.color = new Color32(0, 0, 0, 150);
                        CoolTimeImage.raycastTarget = true;
                        ItemBtn.interactable = false;
                        CoolTimeT.fontSize = 225;
                        CoolTimeT.text = "None";
                    }
                    
                }
                break;
            case ItemType.Heal:
                if (HealC != 0 && GameObject.Find("Player").GetComponent<Player>().Health < GameObject.Find("Player").GetComponent<Player>().tempHealth && GameObject.Find("Player").GetComponent<Player>().Health > 0)
                {
                    UISoundmanager.PlaySound(ItemSound);
                    --HealC;
                    Counttext.text = "x" + HealC;
                    CoolTimeImage.color = new Color32(0, 0, 0, 150);
                    CoolTimeImage.raycastTarget = true;
                    ItemBtn.interactable = false;
                    CoolTimeT.color = new Color32(255, 255, 255, 255);
                    CoolTimeT.raycastTarget = true;
                    HealAnime.SetBool("UseHeal", true);
                    Invoke("HealAnimeOff", 0.5f);
                    player.Healing();

                    if (HealC != 0)
                    {
                        isItemTimeEnd = true;
                        StartCoroutine(CoolTimeCounting(HealCool));
                    }
                    else
                    {
                        CoolTimeT.fontSize = 225;
                        CoolTimeT.text = "None";
                    }
                }
                break;
        }
    }
    IEnumerator CoolTimeCounting(int Cool)
    {
        int tempCool = Cool;
        CoolTimeT.text = Cool.ToString();
        while (Cool != 0)
        {
            yield return null;
            yield return new WaitForSeconds(1f);
            --Cool;
            CoolTimeT.text = Cool.ToString();
        }
        yield return new WaitForSeconds(1f);

        CoolTimeT.color = new Color32(255, 255, 255, 0);
        CoolTimeT.text = tempCool.ToString();
        CoolTimeT.raycastTarget = false;
        isItemCoolEnd = true;
        if (isItemTimeEnd == true && isItemCoolEnd == true)
        {
            CoolTimeImage.color = new Color32(0, 0, 0, 0);
            CoolTimeImage.raycastTarget = false;
            ItemBtn.interactable = true;
            isItemTimeEnd = false;
            isItemCoolEnd = false;
        }
    }
    IEnumerator ShieldCounting()
    {
        yield return null;
        ShieldCountT.text = ShieldTime.ToString();
        int tempShieldTime = ShieldTime;
        yield return new WaitForSeconds(1.5f);
        while(ShieldTime != 0)
        {
            --ShieldTime;
            ShieldCountT.text = ShieldTime.ToString();
            yield return new WaitForSeconds(1f);
        }

        ShieldCount.SetBool("UseShield", false);
        GameObject.Find("Shield_EffectBody").GetComponent<Animator>().SetBool("ShieldOver", true);
        GameObject.Find("Shield_EffectHead").GetComponent<Animator>().SetBool("ShieldOver", true);
        ShieldTime = tempShieldTime;
        yield return new WaitForSeconds(0.5f);
        Destroy(GameObject.Find("ShieldEffect(Clone)"));
        isItemTimeEnd = true;
        if (isItemTimeEnd == true && isItemCoolEnd == true)
        {
            CoolTimeImage.color = new Color32(0, 0, 0, 0);
            CoolTimeImage.raycastTarget = false;
            ItemBtn.interactable = true;
            isItemTimeEnd = false;
            isItemCoolEnd = false;
        }
        yield return new WaitForSeconds(0.3f);
        ShieldCountT.text = "10";
    }
    IEnumerator NightPotionEffect()
    {
        yield return null;
        int tempNPLastTime = NightPotionTime;
        NPLastTime.text = NightPotionTime.ToString();
        NightGGamBBak.SetBool("UseNight", true);
        while(NightPotionTime != 0)
        {
            if ((GameObject.Find("GameManager").GetComponent<GameManager>().Wave + 1) % 5 == 0)
            {
                yield return new WaitForSeconds(1f);
                --NightPotionTime;
                NPLastTime.text = NightPotionTime.ToString();
                if (NightPotionTime <= 3)
                {
                    NightGGamBBak.SetBool("noTime", true);
                }
            }
            else
            {
                break;
            }
        }
        NightGGamBBak.SetBool("UseNight", false);
        yield return new WaitForSeconds(1f);
        NightGGamBBak.SetBool("noTime", false);
        NightGGamBBak.SetBool("IddlenoTime", true);
        yield return new WaitForSeconds(0.4f);
        NightPotionTime = tempNPLastTime;
        NPLastTime.text = NightPotionTime.ToString();
        NightPotion.SetBool("UseNight", false);
        NightGGamBBak.SetBool("IddlenoTime", false);

        isItemTimeEnd = true;
        if (isItemTimeEnd == true && isItemCoolEnd == true)
        {
            CoolTimeImage.color = new Color32(0, 0, 0, 0);
            CoolTimeImage.raycastTarget = false;
            ItemBtn.interactable = true;
            isItemTimeEnd = false;
            isItemCoolEnd = false;
        }
    }
    void HealAnimeOff()
    {
        HealAnime.SetBool("UseHeal", false);
    }
}
