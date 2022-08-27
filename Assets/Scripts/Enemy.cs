using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool isHit;
    public int currentWave;
    public bool isDead;
    Rigidbody2D rigid;
    Animator anime;
    public BoxCollider2D box;
    public AudioClip CollisionSound;
    AudioManager EnemySoundmanager;
    void Awake()
    {
        EnemySoundmanager = GameObject.Find("EnemySoundManager").GetComponent<AudioManager>();
        currentWave = GameObject.Find("GameManager").GetComponent<GameManager>().Wave;

        if (gameObject.name == "Doong_E(Clone)" || gameObject.name == "Doong_W(Clone)" || gameObject.name == "Doong_N(Clone)" || gameObject.name == "Doong_S(Clone)")
        {
            
            if (currentWave < 17)
            {
                speed += 1f * (currentWave - 1);
            }
            else
            {
                speed = 22;
            }
        }
        else if (gameObject.name == "Snaiky_E(Clone)" || gameObject.name == "Snaiky_W(Clone)" || gameObject.name == "Snaiky_N(Clone)" || gameObject.name == "Snaiky_S(Clone)")
        {
            if (currentWave < 22)
            {
                speed += 0.2f * (currentWave - 1);
            }
            else
            {
                speed = 30;
            }
        }
        else if (gameObject.name == "Gboo_E(Clone)" || gameObject.name == "Gboo_W(Clone)" || gameObject.name == "Gboo_N(Clone)" || gameObject.name == "Gboo_S(Clone)")
        {
            if (currentWave < 17)
            {
                speed += 0.5f * (currentWave - 1);
            }
            else
            {
                speed = 15;
            }
        }



        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        MoveEnemy();
    }

    //캐릭터 이동
    void MoveEnemy()
    {
        if(gameObject.tag == "East")
        {
            rigid.velocity = Vector2.left * speed;
        }
        else if(gameObject.tag == "West")
        {
            rigid.velocity = Vector2.right * speed;
        }
        else if(gameObject.tag == "North")
        {
            rigid.velocity = Vector2.down * speed;
        }
        else if(gameObject.tag == "South")
        {
            rigid.velocity = Vector2.up * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            isHit = true;
            EnemySoundmanager.PlaySound(CollisionSound);
            anime.SetBool("isDead", isHit);
            Invoke("DeadColor", 0.5f);

            if (gameObject.tag == "East")
            {
                rigid.velocity = Vector2.left * 0;
                box.offset = new Vector2(0, 0);
            }
            else if (gameObject.tag == "West")
            {
                rigid.velocity = Vector2.right * 0;
                box.offset = new Vector2(0, 0);
            }
            else if (gameObject.tag == "North")
            {
                rigid.velocity = Vector2.down * 0;
                box.offset = new Vector2(0, 0);
            }
            else if (gameObject.tag == "South")
            {
                rigid.velocity = Vector2.up * 0;
                box.offset = new Vector2(0, 0);
            }

            Invoke("Dead", 1.2f);
        }
    }
    void DeadColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 130);
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
