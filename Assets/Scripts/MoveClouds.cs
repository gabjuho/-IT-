using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveClouds : MonoBehaviour
{
    public RectTransform Clouds;
    public float PosX;

    void Start()
    {
        PosX = -3150f;
        Clouds = GameObject.Find("Clouds").GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        Clouds.anchoredPosition = new Vector2(PosX, 164);
        if(PosX == 3300f)
        {
            PosX = -3150f;
        }
        PosX += 0.5f;
    }
}
