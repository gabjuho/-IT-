using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonImageController : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject image;
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
