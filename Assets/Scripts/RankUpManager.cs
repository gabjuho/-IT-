using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankUpManager : MonoBehaviour
{
    public CanvasGroup RankUpWindow;
    public Image NewImage;
    public Image CurrentImage;
    public Sprite[] Rank;
    public Animator CurrentRank;
    public Animator NewRank;
    public Animator RankUpTAnime;
    public Animator UpArrow;
    public Animator TouchScreen;
    public Button NextButton;
    public AudioClip[] RankUpSound;
    public AudioSource BGMmanager;
    AudioManager audiomanager;
    AudioManager ClapSoundmanager;

    public int BestWave;
    // Start is called before the first frame update
    void Start()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        ClapSoundmanager = GameObject.Find("ClapSoundManager").GetComponent<AudioManager>();
        NextButton.interactable = false;
        BestWave = PlayerPrefs.GetInt("BestScore", 0);
        if(BestWave >= 5 && BestWave < 10)
        {
            CurrentImage.sprite = Rank[0];
            NewImage.sprite = Rank[1];
        }
        else if(BestWave >= 10 && BestWave < 15)
        {
            if(PlayerPrefs.GetInt("tempWave",0) < 5)
            {
                CurrentImage.sprite = Rank[0];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 5 && PlayerPrefs.GetInt("tempWave", 0) < 10)
            {
                CurrentImage.sprite = Rank[1];
            }
            NewImage.sprite = Rank[2];
        }
        else if (BestWave >= 15 && BestWave < 20)
        {
            if (PlayerPrefs.GetInt("tempWave", 0) < 5)
            {
                CurrentImage.sprite = Rank[0];
            }
            else if(PlayerPrefs.GetInt("tempWave",0) >= 5 && PlayerPrefs.GetInt("tempWave",0) < 10)
            {
                CurrentImage.sprite = Rank[1];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 10 && PlayerPrefs.GetInt("tempWave", 0) < 15)
            {
                CurrentImage.sprite = Rank[2];
            }
            NewImage.sprite = Rank[3];
        }
        else if (BestWave >= 20 && BestWave < 25)
        {
            if (PlayerPrefs.GetInt("tempWave", 0) < 5)
            {
                CurrentImage.sprite = Rank[0];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 5 && PlayerPrefs.GetInt("tempWave", 0) < 10)
            {
                CurrentImage.sprite = Rank[1];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 10 && PlayerPrefs.GetInt("tempWave", 0) < 15)
            {
                CurrentImage.sprite = Rank[2];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 15 && PlayerPrefs.GetInt("tempWave", 0) < 20)
            {
                CurrentImage.sprite = Rank[3];
            }
            NewImage.sprite = Rank[4];
        }
        else if (BestWave >= 25)
        {
            if (PlayerPrefs.GetInt("tempWave", 0) < 5)
            {
                CurrentImage.sprite = Rank[0];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 5 && PlayerPrefs.GetInt("tempWave", 0) < 10)
            {
                CurrentImage.sprite = Rank[1];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 10 && PlayerPrefs.GetInt("tempWave", 0) < 15)
            {
                CurrentImage.sprite = Rank[2];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 15 && PlayerPrefs.GetInt("tempWave", 0) < 20)
            {
                CurrentImage.sprite = Rank[3];
            }
            else if (PlayerPrefs.GetInt("tempWave", 0) >= 20 && PlayerPrefs.GetInt("tempWave", 0) < 25)
            {
                CurrentImage.sprite = Rank[4];
            }
            NewImage.sprite = Rank[5];
        }


        if (PlayerPrefs.GetInt("tempWave",0) != BestWave && BestWave >= 5 && BestWave < 10 && PlayerPrefs.GetInt("RankUpSilver",0) == 0)
        {
            RankUpWindow.alpha = 1;
            RankUpWindow.blocksRaycasts = true;
            RankUpWindow.interactable = true;
            PlayerPrefs.SetInt("RankUpSilver", 1);
            StartCoroutine(RankAnime());
        }
        else if(PlayerPrefs.GetInt("tempWave", 0) != BestWave && BestWave >= 10 && BestWave < 15 && PlayerPrefs.GetInt("RankUpGold", 0) == 0)
        {
            RankUpWindow.alpha = 1;
            RankUpWindow.blocksRaycasts = true;
            RankUpWindow.interactable = true;
            PlayerPrefs.SetInt("RankUpGold", 1);
            StartCoroutine(RankAnime());
        }
        else if (PlayerPrefs.GetInt("tempWave", 0) != BestWave && BestWave >= 15 && BestWave < 20 && PlayerPrefs.GetInt("RankUpPlatinum", 0) == 0)
        {
            RankUpWindow.alpha = 1;
            RankUpWindow.blocksRaycasts = true;
            RankUpWindow.interactable = true;
            PlayerPrefs.SetInt("RankUpPlatinum", 1);
            StartCoroutine(RankAnime());
        }
        else if (PlayerPrefs.GetInt("tempWave", 0) != BestWave && BestWave >= 20 && BestWave < 25 && PlayerPrefs.GetInt("RankUpDia", 0) == 0)
        {
            RankUpWindow.alpha = 1;
            RankUpWindow.blocksRaycasts = true;
            RankUpWindow.interactable = true;
            PlayerPrefs.SetInt("RankUpDia", 1);
            StartCoroutine(RankAnime());
        }
        else if (PlayerPrefs.GetInt("tempWave", 0) != BestWave && BestWave >= 25 && PlayerPrefs.GetInt("RankUpMaster", 0) == 0)
        {
            RankUpWindow.alpha = 1;
            RankUpWindow.blocksRaycasts = true;
            RankUpWindow.interactable = true;
            PlayerPrefs.SetInt("RankUpMaster", 1);
            StartCoroutine(RankAnime());
        }
        PlayerPrefs.SetInt("tempWave", BestWave);
    }
    IEnumerator RankAnime()
    {
        yield return null;
        BGMmanager.volume = 0.1f;
        yield return new WaitForSeconds(0.5f);
        CurrentRank.SetBool("isRankChange", true);
        audiomanager.PlaySound(RankUpSound[0]);
        yield return new WaitForSeconds(2.3f);
        audiomanager.PlaySound(RankUpSound[1]);
        NewRank.SetBool("isNewRank", true);
        yield return new WaitForSeconds(1.2f);
        audiomanager.PlaySound(RankUpSound[2]);
        Invoke("onClapSound", 0.8f);
        RankUpTAnime.SetBool("RankUpAppear", true);
        yield return new WaitForSeconds(0.6f);
        UpArrow.SetBool("isUpArrow", true);
        TouchScreen.SetBool("isTouchScreen", true);
        NextButton.interactable = true;
    }
    void onClapSound()
    {
        ClapSoundmanager.PlaySound(RankUpSound[3]);
    }
}
