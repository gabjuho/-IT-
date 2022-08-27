using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldTwiceToggle : MonoBehaviour
{
    public int MyGoldTwice;
    public int GetGoldTwice;
    public Text MyGoldTwiceT;
    public Toggle toggle;
    public AudioClip Sound;
    AudioManager audiomanager;

    private void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        MyGoldTwice = PlayerPrefs.GetInt("GoldTwice", 0);
        
        if(MyGoldTwice == 0)
        {
            toggle.interactable = false;
        }
        else
        {
            toggle.interactable = true;
        }
    }
    public void onClickCheck()
    {
        audiomanager.PlaySound(Sound);
        MyGoldTwice = PlayerPrefs.GetInt("GoldTwice", 0);
        if (toggle.isOn == true)
        {
            --MyGoldTwice;
            MyGoldTwiceT.text = "보유수: " + MyGoldTwice.ToString();
            GetGoldTwice = 1;
        }
        else
        {
            MyGoldTwiceT.text = "보유수: " + MyGoldTwice.ToString();
            GetGoldTwice = 0;
        }
    }
}
