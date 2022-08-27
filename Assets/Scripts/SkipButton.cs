using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public void Skip()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().isTouch = true;
    }
}
