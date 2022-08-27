using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    [SerializeField] private InputField NameField;
    [SerializeField] private CanvasGroup InputGroup;
    [SerializeField] private Text Name;
    public CanvasGroup ModifyBtnGroup;

    private void Start()
    {
        if(PlayerPrefs.GetInt("InputComplete",0) == 1)
        {
            InputGroup.alpha = 0;
            InputGroup.blocksRaycasts = false;
            InputGroup.interactable = false;
            ModifyBtnGroup.alpha = 1;
            ModifyBtnGroup.blocksRaycasts = true;
            ModifyBtnGroup.interactable = true;
            Name.text = "이름: " + PlayerPrefs.GetString("Name");
        }
    }
    public void SaveName()
    {
        InputGroup.alpha = 0;
        InputGroup.blocksRaycasts = false;
        InputGroup.interactable = false;
        ModifyBtnGroup.alpha = 1;
        ModifyBtnGroup.blocksRaycasts = true;
        ModifyBtnGroup.interactable = true;
        Name.text = "이름: " + NameField.text;
        PlayerPrefs.SetInt("InputComplete", 1);
        PlayerPrefs.SetString("Name", NameField.text);
    }
}
