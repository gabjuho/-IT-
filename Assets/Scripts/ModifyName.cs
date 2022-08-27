using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyName : MonoBehaviour
{
    public CanvasGroup ModifyBtnWindow;
    public CanvasGroup InputField;
    public Text Name;

    public void onModify()
    {
        ModifyBtnWindow.alpha = 0;
        ModifyBtnWindow.blocksRaycasts = false;
        ModifyBtnWindow.interactable = false;
        InputField.alpha = 1;
        InputField.blocksRaycasts = true;
        InputField.interactable = true;
        Name.text = "이름: "; 
    }
}
