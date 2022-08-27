using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
  
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxcollider;
    Transform trans;
    Animator anime;
    public GameObject[] Heart;
    public Sprite[] HealingHeart;
    public Sprite[] Heart_Image;
    public Transform[] HeartPosition;
    public Sprite[] sprites;
    public GameObject[] HeartType;
    public int Health;
    public int tempHealth;
    public int DoongKill;
    public int SnaikyKill;
    public int GbooKill;
    public int KingDooKill;
    public bool isSodoo;
    public bool gameover;
    public AudioClip MoveSound;
    public AudioClip DamageSound;
    public AudioSource PlayerSound;
    AudioManager PlayerMovemanager;
    AudioManager DamageSoundmanager;
    void Start()
    {
        PlayerMovemanager = GameObject.Find("PlayerSoundManager").GetComponent<AudioManager>();
        DamageSoundmanager = GameObject.Find("DamageSoundManager").GetComponent<AudioManager>();
        gameover = false;
        Health = PlayerPrefs.GetInt("HeartLevel") + 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
        anime = GetComponent<Animator>();
        spriteRenderer.sprite = sprites[0];
        trans = GetComponent<Transform>();
        DrawHeart();
    }

    void DrawHeart()
    {
        tempHealth = Health;
        if(Health % 2 == 0)
        {
            for(int i=0;i<(Health / 2);i++)
            {
                Heart[i] = Instantiate(HeartType[0], HeartPosition[i].position, HeartPosition[i].rotation);
            }
        }
        else if(Health == 1)
        {
            Heart[0] = Instantiate(HeartType[1], HeartPosition[0].position, HeartPosition[0].rotation);
        }
        else
        {
            for (int i = 0; i < (Health / 2); i++)
            {
                Heart[i] = Instantiate(HeartType[0], HeartPosition[i].position, HeartPosition[i].rotation);
            }
            Heart[Health / 2] = Instantiate(HeartType[1], HeartPosition[Health / 2].position, HeartPosition[Health / 2].rotation);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isEast", true);
            spriteRenderer.sprite = sprites[0];
            boxcollider.offset = new Vector2(3f, -0.68f);
            boxcollider.size = new Vector2(0.2f, 4.355431f);
            trans.position = new Vector2(0.89f, 1.47f);

        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isWest", true);
            spriteRenderer.sprite = sprites[1];
            boxcollider.offset = new Vector2(-3f, -0.68f);
            boxcollider.size = new Vector2(0.2f, 4.355431f);
            trans.position = new Vector2(-0.89f, 1.47f);

        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isNorth", true);
            spriteRenderer.sprite = sprites[2];
            boxcollider.offset = new Vector2(0, 1.6f);
            boxcollider.size = new Vector2(4.355431f, 0.2f);
            trans.position = new Vector2(0.7f, 4.6f);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isSouth", true);
            spriteRenderer.sprite = sprites[3];
            boxcollider.offset = new Vector2(0, -2f);
            boxcollider.size = new Vector2(4.355431f, 0.2f);
            trans.position = new Vector2(0.7f, -3f);
        }
    }
    public void Damage(GameObject monster)
    {

        if(monster.name == "KingDoo_E(Clone)" || monster.name == "KingDoo_W(Clone)" || monster.name == "KingDoo_N(Clone)" || monster.name == "KingDoo_S(Clone)")
        {
            isSodoo = GameObject.Find(monster.name).GetComponent<KingDoo>().isSodoo;
        }
        if((monster.name == "KingDoo_E(Clone)"|| monster.name == "KingDoo_W(Clone)" || monster.name == "KingDoo_N(Clone)" || monster.name == "KingDoo_S(Clone)") && isSodoo == false)
        {
            KingDooDamage();
        }
        else 
        {
            DamageHeart(); 
        }

        Destroy(monster);
        ChangeColor();
    }
    void ChangeColor()
    {
        DamageSoundmanager.PlaySound(DamageSound);
        if(Health > 0)
        {
            spriteRenderer.color = new Color32(253, 130, 130, 255);
            Invoke("returnColor", 0.1f);
        }  
    }
    void returnColor()
    {
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }
    void DamageHeart()
    {
        if (Health > 0)
        {
            if (Health % 2 == 0)
            {
                Heart[Health / 2 - 1].gameObject.GetComponent<SpriteRenderer>().sprite = Heart_Image[0];
            }
            else if (Health % 2 != 0)
            {
                Heart[Health / 2].gameObject.GetComponent<SpriteRenderer>().sprite = Heart_Image[1];
            }
            --Health;
            if(Health <= 0)
            {
                gameover = true;
                trans.position = new Vector2(0.89f, 1.47f);
                anime.SetBool("isDead", true);
                GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            }
        }
    }
    void KingDooDamage()
    {
        if (Health > 0)
        {
            if (Health % 2 == 0)
            {
                Heart[Health / 2 - 1].gameObject.GetComponent<SpriteRenderer>().sprite = Heart_Image[1];
                Health -= 2;
            }
            else if (Health % 2 != 0)
            {
                if (Health >= 2)
                {
                    Heart[Health / 2].gameObject.GetComponent<SpriteRenderer>().sprite = Heart_Image[1];
                    Heart[Health / 2 - 1].gameObject.GetComponent<SpriteRenderer>().sprite = Heart_Image[0];
                }
                else
                {
                    Heart[0].gameObject.GetComponent<SpriteRenderer>().sprite = Heart_Image[1];
                }
                Health -= 2;
            }
            if (Health <= 0)
            {
                gameover = true;
                trans.position = new Vector2(0.89f, 1.47f);
                anime.SetBool("isDead", true);
                GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            }
        }
    }
    public void Healing()
    {
        if(Health > 0 && Health < tempHealth && gameover == false)
        {
            if (Health % 2 == 0)
            {
                Heart[Health / 2].gameObject.GetComponent<SpriteRenderer>().sprite = HealingHeart[1];
            }
            else if(Health % 2 != 0)
            {
                Heart[Health / 2].gameObject.GetComponent<SpriteRenderer>().sprite = HealingHeart[0];
            }
            ++Health;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "Doong_E(Clone)" || collision.gameObject.name == "Doong_W(Clone)" || collision.gameObject.name == "Doong_N(Clone)" || collision.gameObject.name == "Doong_S(Clone)") && gameover == false)
        {
            ++DoongKill;
        }
        else if ((collision.gameObject.name == "Snaiky_E(Clone)" || collision.gameObject.name == "Snaiky_W(Clone)" || collision.gameObject.name == "Snaiky_N(Clone)" || collision.gameObject.name == "Snaiky_S(Clone)") && gameover == false)
        {
            ++SnaikyKill;
        }
        else if ((collision.gameObject.name == "Gboo_E(Clone)" || collision.gameObject.name == "Gboo_W(Clone)" || collision.gameObject.name == "Gboo_N(Clone)" || collision.gameObject.name == "Gboo_S(Clone)") && gameover == false)
        {
            ++GbooKill;
        }
    }
    
}