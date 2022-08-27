using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmBtn : MonoBehaviour
{
    private int ShieldCount;
    private int HealCount;
    private int NightCount;
    private int GoldTwiceCount;
    private int myShield;
    private int myHeal;
    private int myNight;
    private int myGoldTwice;
    public AudioClip Sound;
    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void PlayBtn()
    {
        audiomanager.PlaySound(Sound);
        myShield = PlayerPrefs.GetInt("ProtectShield", 0);
        myHeal = PlayerPrefs.GetInt("HealPotion", 0);
        myNight = PlayerPrefs.GetInt("NightPotion", 0);
        myGoldTwice = PlayerPrefs.GetInt("GoldTwice", 0);
        ShieldCount = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield;
        HealCount = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal;
        NightCount = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night;
        GoldTwiceCount = GameObject.Find("Toggle").GetComponent<GoldTwiceToggle>().GetGoldTwice;

        PlayerPrefs.SetInt("ProtectShield", myShield - ShieldCount);
        PlayerPrefs.SetInt("HealPotion", myHeal - HealCount);
        PlayerPrefs.SetInt("NightPotion", myNight - NightCount);
        PlayerPrefs.SetInt("GoldTwice", myGoldTwice - GoldTwiceCount);

        PlayerPrefs.SetInt("ShieldB", ShieldCount);
        PlayerPrefs.SetInt("HealB", HealCount);
        PlayerPrefs.SetInt("NightB", NightCount);
        PlayerPrefs.SetInt("GoldTwiceB", GoldTwiceCount);
        Invoke("GameStart", 0.7f);
    }
    void GameStart()
    {
        SceneManager.LoadScene("Loading3");
    }
}
