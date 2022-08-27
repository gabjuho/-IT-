using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BtnType4
{
    Buy
}
public class ShopGoldManager : MonoBehaviour
{
    public BtnType4 currentType;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI ItemPrice;
    public AudioClip Coin3;
    public AudioManager audiomanager;

    GoldManager goldmanager;
    public void Start()
    {
        goldmanager = GameObject.Find("GoldManager").GetComponent<GoldManager>();
        goldmanager.NightPotion = PlayerPrefs.GetInt("NightPotion",0);
        goldmanager.HealPotion = PlayerPrefs.GetInt("HealPotion", 0);
        goldmanager.ProtectShield = PlayerPrefs.GetInt("ProtectShield", 0);
        goldmanager.GoldTwice = PlayerPrefs.GetInt("GoldTwice", 0);
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onBtnClick()
    {
        if(currentType == BtnType4.Buy)
        {
            if (goldmanager.Gold >= int.Parse(ItemPrice.text))
            {
                goldmanager.Gold -= int.Parse(ItemPrice.text);
                PlayerPrefs.SetInt("Gold", goldmanager.Gold);
                GoldText.text = goldmanager.Gold.ToString();
                if(ItemPrice.text == "60")
                {
                    ++goldmanager.NightPotion;
                    PlayerPrefs.SetInt("NightPotion", goldmanager.NightPotion);
                    GameObject.Find("MyItemResetManager").GetComponent<MyItemReset>().ChangeMyNight(goldmanager.NightPotion);
                }
                else if(ItemPrice.text == "80")
                {
                    ++goldmanager.HealPotion;
                    PlayerPrefs.SetInt("HealPotion", goldmanager.HealPotion);
                    GameObject.Find("MyItemResetManager").GetComponent<MyItemReset>().ChangeMyHeal(goldmanager.HealPotion);
                }
                else if (ItemPrice.text == "90")
                {
                    ++goldmanager.GoldTwice;
                    PlayerPrefs.SetInt("GoldTwice", goldmanager.GoldTwice);
                    GameObject.Find("MyItemResetManager").GetComponent<MyItemReset>().ChangeMyGoldTwice(goldmanager.GoldTwice);
                }
                else if (ItemPrice.text == "100")
                {
                    ++goldmanager.ProtectShield;
                    PlayerPrefs.SetInt("ProtectShield", goldmanager.ProtectShield);
                    GameObject.Find("MyItemResetManager").GetComponent<MyItemReset>().ChangeMyShield(goldmanager.ProtectShield);
                }
                audiomanager.PlaySound(Coin3);
            }
            else
            {
                Debug.Log("너무 비쌉니다.");
            }
        }
    }

}
