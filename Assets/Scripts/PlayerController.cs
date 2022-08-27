using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerType
{
    East,
    West,
    North,
    South
}
public class PlayerController : MonoBehaviour
{
    public ControllerType currentType;
    public SpriteRenderer spriteRenderer;
    public Sprite sprites;
    public BoxCollider2D boxcollider;
    public Transform trans;
    public Animator anime;
    public AudioClip MoveSound;
    AudioManager PlayerMovemanager;
    private void Awake()
    {
        PlayerMovemanager = GameObject.Find("PlayerSoundManager").GetComponent<AudioManager>();
    }
    public void onBtnClick()
    {
        if (currentType == ControllerType.East && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isEast", true);

            spriteRenderer.sprite = sprites;
            boxcollider.offset = new Vector2(3f, -0.68f);
            boxcollider.size = new Vector2(0.2f, 4.355431f);
            trans.position = new Vector2(0.89f, 1.47f);
        }
        else if (currentType == ControllerType.West && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isWest", true);

            spriteRenderer.sprite = sprites;
            boxcollider.offset = new Vector2(-3f, -0.68f);
            boxcollider.size = new Vector2(0.2f, 4.355431f);
            trans.position = new Vector2(-0.89f, 1.47f);
        }
        else if (currentType == ControllerType.North && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isNorth", true);

            spriteRenderer.sprite = sprites;
            boxcollider.offset = new Vector2(0, 1.6f);
            boxcollider.size = new Vector2(4.355431f, 0.2f);
            trans.position = new Vector2(0.7f, 4.6f);
        }
        else if (currentType == ControllerType.South && GameObject.Find("Player").GetComponent<Player>().gameover == false)
        {
            PlayerMovemanager.PlaySound(MoveSound);
            anime.SetBool("isEast", false);
            anime.SetBool("isWest", false);
            anime.SetBool("isNorth", false);
            anime.SetBool("isSouth", false);

            anime.SetBool("isSouth", true);

            spriteRenderer.sprite = sprites;
            boxcollider.offset = new Vector2(0, -2f);
            boxcollider.size = new Vector2(4.355431f, 0.2f);
            trans.position = new Vector2(0.7f, -3f);
        }
    }
}