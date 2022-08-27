using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySoundBtn : MonoBehaviour
{
    public Sprite[] SoundSprite;
    public Image LobbySoundImage;
    public AudioSource[] audiomanager;
    int isOn;
    private void Start()
    {
        isOn = PlayerPrefs.GetInt("volume", 0);

        if(isOn == 0)
        {
            LobbySoundImage.sprite = SoundSprite[0];
        }
        else
        {
            for(int i=0;i<3;i++)
            {
                audiomanager[i].volume = 0;
            }
            LobbySoundImage.sprite = SoundSprite[1];
        }
    }
    public void onLobbySoundBtn()
    {
        if(isOn == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                audiomanager[i].volume = 0;
            }
            isOn = 1;
            LobbySoundImage.sprite = SoundSprite[1];
            PlayerPrefs.SetInt("volume", isOn);
        }
        else
        {
            SoundOn();
            isOn = 0;
            LobbySoundImage.sprite = SoundSprite[0];
            PlayerPrefs.SetInt("volume", isOn);
        }
    }
    void SoundOn()
    {
        audiomanager[0].volume = 1;
        audiomanager[1].volume = 1;
        audiomanager[2].volume = 0.5f;
    }
}
