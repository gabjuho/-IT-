using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TipBtnColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject image;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable == true)
        {
            image.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Button>().interactable == true)
        {
            image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
