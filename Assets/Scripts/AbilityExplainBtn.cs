using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AbilityType
{
    Heart,
    BackPack,
    Attack
}
public class AbilityExplainBtn : MonoBehaviour
{
    public AbilityType currentType;
    public Sprite ChangeSprite;
    public Image AbilityImage;
    public Image FadeImage;
    public CanvasGroup AbilityExplainWindow;
    public CanvasGroup ProfileBackG;
    public Button ProfileBack;
    public Text AbilityName;
    public Text AbilityExplain;
    public AudioClip Sound;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void onAbilityExplainWindow()
    {
        audiomanager.PlaySound(Sound);
        ProfileBack.interactable = false;
        ProfileBackG.alpha = 0;
        AbilityExplainWindow.alpha = 1;
        AbilityExplainWindow.blocksRaycasts = true;
        AbilityExplainWindow.interactable = true;
        AbilityImage.sprite = ChangeSprite;
        FadeImage.color = new Color32(0, 0, 0, 50);
        FadeImage.raycastTarget = true;
        switch(currentType)
        {
            case AbilityType.Heart:
                AbilityName.text = "체력";
                AbilityName.color = new Color32(255, 66, 66, 255);
                AbilityExplain.text = "용사의 체력을 높여주는 능력이다.\n체력이 높으면 높을수록 생존시간이 늘어난다.";
                break;
            case AbilityType.BackPack:
                AbilityName.text = "소유 공간";
                AbilityName.color = new Color32(255, 127, 8, 255);
                AbilityExplain.text = "전장에 가져갈 수 있는 아이템의 개수를 늘려준다. 아이템은 많을수록 좋으니 꼭 올려두도록 하자.";
                break;
            case AbilityType.Attack:
                AbilityName.text = "공격력";
                AbilityName.color = new Color32(248, 105, 64, 255);
                AbilityExplain.text = "웨이브 10부터 등장하는 킹두는 다른 몬스터에 비해 단단하므로 방패의 공격력을 올려주도록 하자.";
                break;
        }
    }
    public void BackBtn()
    {
        audiomanager.PlaySound(Sound);
        AbilityExplainWindow.alpha = 0;
        AbilityExplainWindow.blocksRaycasts = false;
        AbilityExplainWindow.interactable = false;
        FadeImage.color = new Color32(0, 0, 0, 0);
        FadeImage.raycastTarget = false;
        ProfileBack.interactable = true;
        ProfileBackG.alpha = 1;
    }
}
