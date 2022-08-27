using UnityEngine;
using UnityEngine.UI;

public enum ItemBtnType
{
    ShieldM,
    ShieldP,
    HealM,
    HealP,
    NightM,
    NightP
}
public class ItemCountBtn : MonoBehaviour
{
    public ItemBtnType itemBtnType;
    public int ShieldCount;
    public int HealCount;
    public int NightCount;
    public int myShield;
    public int myHeal;
    public int myNight;
    public Text Shield;
    public Text Heal;
    public Text Night;
    public Text myShieldT;
    public Text myHealT;
    public Text myNightT;
    public AudioClip Sound;
    AudioManager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    public void itembtntype()
    {
        myShield = PlayerPrefs.GetInt("ProtectShield", 0);
        myHeal = PlayerPrefs.GetInt("HealPotion", 0);
        myNight = PlayerPrefs.GetInt("NightPotion", 0);

        switch (itemBtnType)
        {
            case ItemBtnType.ShieldM:
                if (GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield != 0)
                {
                    audiomanager.PlaySound(Sound);
                    --GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield;
                    Shield.text = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield.ToString();
                    myShieldT.text = "보유수: " + (myShield - GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield);
                }
                break;
            case ItemBtnType.ShieldP:
                if ((GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night + GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal + GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield) != (PlayerPrefs.GetInt("ProtectLevel",0) + 3) && GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield != myShield)
                {
                    audiomanager.PlaySound(Sound);
                    ++GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield;
                    Shield.text = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield.ToString();
                    myShieldT.text = "보유수: " + (myShield - GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield);
                }
                break;
            case ItemBtnType.HealM:
                if (GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal != 0)
                {
                    audiomanager.PlaySound(Sound);
                    --GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal;
                    Heal.text = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal.ToString();
                    myHealT.text = "보유수: " + (myHeal - GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal);
                }
                break;
            case ItemBtnType.HealP:
                if ((GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night + GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal + GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield) != (PlayerPrefs.GetInt("ProtectLevel", 0) + 3) && GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal != myHeal)
                {
                    audiomanager.PlaySound(Sound);
                    ++GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal;
                    Heal.text = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal.ToString();
                    myHealT.text = "보유수: " + (myHeal - GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal);
                }
                break;
            case ItemBtnType.NightM:
                if (GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night != 0)
                {
                    audiomanager.PlaySound(Sound);
                    --GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night;
                    Night.text = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night.ToString();
                    myNightT.text = "보유수: " + (myNight - GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night);
                }
                break;
            case ItemBtnType.NightP:
                if ((GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night + GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Heal + GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Shield) != (PlayerPrefs.GetInt("ProtectLevel", 0) + 3) && GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night != myNight)
                {
                    audiomanager.PlaySound(Sound);
                    ++GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night;
                    Night.text = GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night.ToString();
                    myNightT.text = "보유수: " + (myNight - GameObject.Find("ItemCountingManager").GetComponent<ItemCountManager>().Night);
                }
                break;
        }
    }
}
