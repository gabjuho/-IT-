using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTextChange : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Text SelectT;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectT.color = new Color32(125, 125, 125, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SelectT.color = new Color32(255, 255, 255, 255);
    }
}
