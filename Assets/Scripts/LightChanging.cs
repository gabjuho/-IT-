using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanging : MonoBehaviour
{
    Animator lightani;
    public int currentWave;
    // Start is called before the first frame update
    void Start()
    {
        lightani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = GameObject.Find("GameManager").GetComponent<GameManager>().Wave;

        if((currentWave + 2) % 5 == 0)
        {
            lightani.SetBool("isEvening", true);
            lightani.SetBool("isAfternoon", false);
        }
        else if((currentWave + 1) % 5 == 0)
        {
            lightani.SetBool("isNight", true);
            lightani.SetBool("isEvening", false);
        }
        else if(currentWave % 5 == 0)
        {
            lightani.SetBool("isMorning", true);
            lightani.SetBool("isNight", false);
        }
        else if((currentWave + 4) % 5 == 0 || (currentWave + 3) % 5 == 0)
        {
            lightani.SetBool("isAfternoon", true);
            lightani.SetBool("isMorning", false);
        }
    }
}
