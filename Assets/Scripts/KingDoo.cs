using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDoo : MonoBehaviour
{
    Animator anime;
    Rigidbody2D rigid;
    BoxCollider2D boxcollider;
    AudioManager EnemySoundManager;
    public float speed;
    public float knockback;
    public float Sspeed;
    public int Health;
    public bool isBorn;
    public bool isSodoo;
    public int currentWave;
    public AudioClip CollisionSound;
    int AttackLevel;
    
    private void Start()
    {
        AttackLevel = PlayerPrefs.GetInt("AttackLevel", 0);
        EnemySoundManager = GameObject.Find("EnemySoundManager").GetComponent<AudioManager>();
        currentWave = GameObject.Find("GameManager").GetComponent<GameManager>().Wave;
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        if(currentWave < 22)
        {
            speed += 0.5f * (currentWave - 1);
        }
        else
        {
            speed = 15;
        }
        if(currentWave < 13)
        {
            Health = 2;
        }
        else if(currentWave >= 13 && currentWave <16)
        {
            Health = 3;
        }
        else if(currentWave >= 16 && currentWave <19)
        {
            Health = 4;
        }
        else if(currentWave >= 19)
        {
            Health = 5;
        }
        Move();
    }

    void Move()
    {
        if(gameObject.tag == "East")
        {
            rigid.velocity = Vector2.left * speed;
        }
        else if(gameObject.tag == "West")
        {
            rigid.velocity = Vector2.right * speed;
        }
        else if (gameObject.tag == "North")
        {
            rigid.velocity = Vector2.down * speed;
        }
        else if (gameObject.tag == "South")
        {
            rigid.velocity = Vector2.up * speed;
        }
    }

    //체력 구현, 넉백 애니메이션 구현
    void KnockBack()
    {
        anime.SetBool("isHit", true);
        Health -= (AttackLevel + 1);
        if (gameObject.tag == "East")
        {
            rigid.velocity = Vector2.left * 0;
            rigid.AddForce(Vector2.right * knockback, ForceMode2D.Impulse);
        }
        else if (gameObject.tag == "West")
        {
            rigid.velocity = Vector2.right * 0;
            rigid.AddForce(Vector2.left * knockback, ForceMode2D.Impulse);
        }
        else if (gameObject.tag == "North")
        {
            rigid.velocity = Vector2.down * 0;
            rigid.AddForce(Vector2.up * knockback, ForceMode2D.Impulse);
        }
        else if (gameObject.tag == "South")
        {
            rigid.velocity = Vector2.up * 0;
            rigid.AddForce(Vector2.down * knockback, ForceMode2D.Impulse);
        }

        if (Health > 0)
        {
            Invoke("MoveAgain", 0.5f);
        }
        else
        {
            Invoke("KDead", 0.2f);
        }
    }

    void MoveAgain()
    {
        anime.SetInteger("Health", Health);
        anime.SetBool("isHit", false);

        if (gameObject.tag == "East")
        {
            rigid.velocity = Vector2.left * speed;
        }
        else if (gameObject.tag == "West")
        {
            rigid.velocity = Vector2.right * speed;
        }
        else if (gameObject.tag == "North")
        {
            rigid.velocity = Vector2.down * speed;
        }
        else if (gameObject.tag == "South")
        {
            rigid.velocity = Vector2.up * speed;
        }
    }

    void KDead()
    {
        anime.SetInteger("Health", Health);
        if (gameObject.tag == "East")
        {
            rigid.velocity = Vector2.right * 0;
        }
        else if (gameObject.tag == "West")
        {
            rigid.velocity = Vector2.left * 0;
        }
        else if (gameObject.tag == "North")
        {
            rigid.velocity = Vector2.up * 0;
        }
        else if (gameObject.tag == "South")
        {
            rigid.velocity = Vector2.down * 0;
        }
        isSodoo = true;
        Invoke("SMove", 1f);
    }

    void SMove()
    {
        isBorn = true;
        anime.SetBool("isBorn", true);
        if(gameObject.tag == "East")
        {
            boxcollider.offset = new Vector2(-2.8f, -7f);
            boxcollider.size = new Vector2(0.2f, 3f);
            rigid.velocity = Vector2.left * Sspeed;
        }
        else if(gameObject.tag == "West")
        {
            boxcollider.offset = new Vector2(-2.8f, -7f);
            boxcollider.size = new Vector2(0.2f, 3f);
            rigid.velocity = Vector2.right * Sspeed;
        }
        else if(gameObject.tag == "North")
        {
            boxcollider.offset = new Vector2(0f, -8f);
            boxcollider.size = new Vector2(3f, 0.2f);
            rigid.velocity = Vector2.down * Sspeed;
        }
        else if(gameObject.tag == "South")
        {
            boxcollider.offset = new Vector2(0f, -3.7f);
            boxcollider.size = new Vector2(3.2f, 0.2f);
            rigid.velocity = Vector2.up * Sspeed;
        }
    }
    
    void SDead()
    {
        anime.SetBool("isSHit", true);

        if (GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            ++GameObject.Find("Player").GetComponent<Player>().KingDooKill;
        }

        if (gameObject.tag == "East")
        {
            rigid.velocity = Vector2.left * 0;
            boxcollider.offset = new Vector2(0, 0);
        }
        else if (gameObject.tag == "West")
        {
            rigid.velocity = Vector2.right * 0;
            boxcollider.offset = new Vector2(0, 0);
        }
        else if (gameObject.tag == "North")
        {
            rigid.velocity = Vector2.down * 0;
            boxcollider.offset = new Vector2(0, 0);
        }
        else if (gameObject.tag == "South")
        {
            rigid.velocity = Vector2.up * 0;
            boxcollider.offset = new Vector2(0, -5);
        }
        Invoke("RemoveObject", 0.6f);
    }

    void RemoveObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shield" && isBorn == false)
        {
            EnemySoundManager.PlaySound(CollisionSound);
            KnockBack();
        }
        else if(collision.gameObject.tag == "Shield" && isBorn == true)
        {
            EnemySoundManager.PlaySound(CollisionSound);
            SDead();
        }
    }
}
