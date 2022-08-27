using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldKillCount : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "Doong_E(Clone)" || collision.gameObject.name == "Doong_W(Clone)" || collision.gameObject.name == "Doong_N(Clone)" || collision.gameObject.name == "Doong_S(Clone)") && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            ++GameObject.Find("Player").GetComponent<Player>().DoongKill;
        }
        else if ((collision.gameObject.name == "Snaiky_E(Clone)" || collision.gameObject.name == "Snaiky_W(Clone)" || collision.gameObject.name == "Snaiky_N(Clone)" || collision.gameObject.name == "Snaiky_S(Clone)") && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            ++GameObject.Find("Player").GetComponent<Player>().SnaikyKill;
        }
        else if ((collision.gameObject.name == "Gboo_E(Clone)" || collision.gameObject.name == "Gboo_W(Clone)" || collision.gameObject.name == "Gboo_N(Clone)" || collision.gameObject.name == "Gboo_S(Clone)") && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            ++GameObject.Find("Player").GetComponent<Player>().GbooKill;
        }
    }
}
