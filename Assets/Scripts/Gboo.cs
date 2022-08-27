using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gboo : MonoBehaviour
{
    public Transform[] movingPoint;
    public GameObject[] ChangeObject;
    public Transform Rotation;
    public int ranPosition;
    public bool istouch;
    public AudioClip GbooMoveSound;
    Transform currentTrans;
    Rigidbody2D rigids;
    Animator animate;
    BoxCollider2D boxcollider;
    AudioManager GbooSoundmanager;
    private void Start()
    {
        GbooSoundmanager = GameObject.Find("GbooSoundManager").GetComponent<AudioManager>();
        istouch = false;
        currentTrans = GetComponent<Transform>();
        rigids = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (istouch == true)
        {
            currentTrans.position = Vector2.Lerp(currentTrans.position, movingPoint[ranPosition].position, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GbooLine")
        {
            if(gameObject.tag == "East")
            {
                rigids.velocity = Vector2.left * 0;
            }
            else if(gameObject.tag == "West")
            {
                rigids.velocity = Vector2.right * 0;
            }
            else if (gameObject.tag == "North")
            {
                rigids.velocity = Vector2.down * 0;
            }
            else if (gameObject.tag == "South")
            {
                rigids.velocity = Vector2.up * 0;
            }
            boxcollider.offset = new Vector2(1000, 0);
            ranPosition = Random.Range(0, 2);
            if (ranPosition == 0)
            {
                animate.SetBool("isTouch0", true);
            }
            else
            {
                animate.SetBool("isTouch1", true);
            }
            istouch = true;
            GbooSoundmanager.PlaySound(GbooMoveSound);
            Invoke("DestroyObject", 1f);
        }
    }
    void DestroyObject()
    {
        if (ChangeObject[ranPosition].tag == "West")
        {
            Instantiate(ChangeObject[ranPosition], movingPoint[ranPosition].position, Rotation.rotation);
        }
        else
        {
            Instantiate(ChangeObject[ranPosition], movingPoint[ranPosition].position, movingPoint[ranPosition].rotation);
        }
        Destroy(gameObject);
    }


}
