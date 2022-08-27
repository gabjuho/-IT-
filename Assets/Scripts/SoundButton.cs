using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundButton : MonoBehaviour
{
    public Image SoundBtnImage;
    public Sprite[] SoundImageSource;
    public AudioSource[] audioGroup;
    int isOn;

    private void Start()
    {
        isOn = PlayerPrefs.GetInt("volume", 0);
        if (isOn == 0)
        {
            SoundBtnImage.sprite = SoundImageSource[0];
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                audioGroup[i].volume = 0;
            }
            SoundBtnImage.sprite = SoundImageSource[1];
        }
    }
    public void onSoundBtn()
    {
        if(isOn == 0)
        {
            for(int i=0;i<8;i++)
            {
                audioGroup[i].volume = 0;
            }
            SoundBtnImage.sprite = SoundImageSource[1];
            isOn = 1;
            PlayerPrefs.SetInt("volume", isOn);
        }
        else
        {
            changeOriginVolume();
            SoundBtnImage.sprite = SoundImageSource[0];
            isOn = 0;
            PlayerPrefs.SetInt("volume", isOn);
        }
    }
    void changeOriginVolume()
    {
        audioGroup[0].volume = 1;
        audioGroup[1].volume = 1;
        audioGroup[2].volume = 0.4f;
        audioGroup[3].volume = 0.4f;
        audioGroup[4].volume = 0.6f;
        audioGroup[5].volume = 1f;
        audioGroup[6].volume = 0.1f;
        audioGroup[7].volume = 0.1f;
    }
}
