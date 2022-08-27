using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject ShopBackground;
    public GameObject LobbyBackground;
    public void ShopBackGround()
    {
        ShopBackground.GetComponent<Transform>().position = new Vector3(1, -1.38015f, 0);
        LobbyBackground.GetComponent<Transform>().position = new Vector3(-600, 0, 0);
    }
    public void LobbyBackGround()
    {
        ShopBackground.GetComponent<Transform>().position = new Vector3(-600, 0, 0);
        LobbyBackground.GetComponent<Transform>().position = new Vector3(1, -1.38015f, 0);
    } 
}
