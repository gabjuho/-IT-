using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoButtonImageChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image1;
    public Image image2;
    public void OnPointerEnter(PointerEventData eventData)
    {
        image1.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
        image2.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        image2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}