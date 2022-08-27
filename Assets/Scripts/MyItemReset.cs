using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyItemReset : MonoBehaviour
{
    public Text MyShield;
    public Text MyHeal;
    public Text MyNight;
    public Text MyGoldTwice;
    public Text MaxItem;
    public Text cShield;
    public Text cHeal;
    public Text cNight;
    public TextMeshProUGUI HMax;
    public TextMeshProUGUI PMax;
    public TextMeshProUGUI AMax;

    private void Start()
    {
        MyShield.text = "보유수: " + PlayerPrefs.GetInt("ProtectShield", 0);
        MyHeal.text = "보유수: " + PlayerPrefs.GetInt("HealPotion", 0);
        MyNight.text = "보유수: " + PlayerPrefs.GetInt("NightPotion", 0);
        MyGoldTwice.text = "보유수: " + PlayerPrefs.GetInt("GoldTwice", 0);
        MaxItem.text = "최대 소지수: " + (3 + PlayerPrefs.GetInt("ProtectLevel", 0));
        if(PlayerPrefs.GetInt("ProtectLevel",0) == 5)
        {
            PMax.color = new Color32(255, 255, 255, 255);
        }
        if(PlayerPrefs.GetInt("HeartLevel",0) == 7)
        {
            HMax.color = new Color32(255, 255, 255, 255);
        }
        if(PlayerPrefs.GetInt("AttackLevel",0) == 4)
        {
            AMax.color = new Color32(255, 255, 255, 255);
        }
    }
    public void ChangeMyShield(int Count)
    {
        MyShield.text = "보유수: " + (Count - int.Parse(cShield.text));
    }
    public void ChangeMyHeal(int Count)
    {
        MyHeal.text = "보유수: " + (Count - int.Parse(cHeal.text));
    }
    public void ChangeMyNight(int Count)
    {
        MyNight.text = "보유수: " + (Count - int.Parse(cNight.text));
    }
    public void ChangeMyGoldTwice(int Count)
    {
        if (GameObject.Find("Toggle").GetComponent<GoldTwiceToggle>().toggle.isOn == true)
        {
            MyGoldTwice.text = "보유수: " + (Count - 1);
        }
        else
        {
            MyGoldTwice.text = "보유수: " + Count;
        }
        GameObject.Find("Toggle").GetComponent<GoldTwiceToggle>().toggle.interactable = true;
    }
    public void ChangeMaxItem()
    {
        MaxItem.text = "최대 소지수: " + (3 + PlayerPrefs.GetInt("ProtectLevel", 0));
    }
}
