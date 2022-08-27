using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public Transform[] KingDooSpawnPoint;
    public GameObject[] E_Enemy;
    public GameObject[] W_Enemy;
    public GameObject[] N_Enemy;
    public GameObject[] S_Enemy;
    public GameObject count;
    public float curspawnDelay;
    public float maxDelay;
    public float WaveTime;
    public float WaveMaxTime;
    public float tempMaxTime;
    public bool GameStart;
    public bool waveend;
    public bool isTouch;
    public Image Ingame;
    public CanvasGroup IngameGroup;
    public CanvasGroup RewardWindow;
    public CanvasGroup ScoreGroup;
    public CanvasGroup AccountGroup;
    public CanvasGroup LobbyBtnGroup;
    public CanvasGroup SkipBtnGroup;
    public Animator anime;
    public Animator WaveAnime;
    public Animator Rewardanime;
    public Animator Scoreanime;
    public Animator BestWaveanime;
    public Animator Accountanime;
    public Animator GameOveranime;
    public int DCount;
    public int SCount;
    public int GCount;
    public int KCount;
    public int ranEnemy;
    public int BestWave;
    public int Wave;
    public int Health;
    public int FinalScore;
    public int RewardGold;
    public int MyGold;
    int GoldTwiceCount;
    public Text Doong;
    public Text Snailky;
    public Text Gboo;
    public Text KingDoo;
    public Text Title;
    public Text Wavenumber;
    public Text NextWavenumber;
    public Text countingText;
    public Text WaveCount;
    public Text BestWaveCount;
    public Text ADoong;
    public Text ASnailky;
    public Text AGboo;
    public Text AKingDoo;
    public Text AWave;
    public Text AGold;
    public Text GoldTwiceT;
    public AudioClip WaveSound;
    public AudioClip GameOverSound;
    public AudioClip[] UISound;
    AudioManager Waveaudiomanager;
    AudioManager UISoundmanager;
    AudioManager GameOverSoundmanager;
    public AudioSource BGMmanager;
    public UsingItem[] UsingItemClass;
    int temp;
    private void Start() // 플레이 버튼 클릭 후 플레이 씬으로 화면 전환이 되었을 때 실행
    {
        UISoundmanager = GameObject.Find("UISoundManager").GetComponent<AudioManager>();
        Waveaudiomanager = GameObject.Find("WaveSoundManager").GetComponent<AudioManager>(); //효과음 및 UI사운드 매니저 불러오기
        GoldTwiceCount = PlayerPrefs.GetInt("GoldTwiceB", 0); //골드 2배 쿠폰 사용 여부
        BestWave = PlayerPrefs.GetInt("BestScore", 0); //이전에 달성했던 최고 웨이브 불러오기 (없다면 0웨이브)
        Ingame.color = new Color32(0, 0, 0, 100);
        IngameGroup.blocksRaycasts = false;
        IngameGroup.interactable = false;

        StartCoroutine("StartCounting");
    }

    IEnumerator StartCounting()
    {
        yield return new WaitForSeconds(1f); //게임시작까지 1초씩 카운트
        countingText.text = "2";
        yield return new WaitForSeconds(1f);
        countingText.text = "1";
        yield return new WaitForSeconds(1f);
        countingText.text = "Go!";
        yield return new WaitForSeconds(1f);
        gameStart();
    }
    void gameStart() //게임시작
    {
        Ingame.color = new Color32(0, 0, 0, 0); //플레이 화면의 밤 낮 여부
        IngameGroup.blocksRaycasts = true;
        IngameGroup.interactable = true;
        countingText.color = new Color(255, 255, 255, 0);
        BGMmanager.Play();
        WaveAnime.SetBool("WaveStart", true); //게임이 시작했음을 알리는 변수
        Invoke("onWaveSound", 0.6f);
        Invoke("RealStart", 2f);
    }
    void onWaveSound() //웨이브 변경될 때 마다 호출
    {
        Waveaudiomanager.PlaySound(WaveSound);
    }
    void RealStart()
    {
        WaveAnime.SetBool("WaveStart", false);
        GameStart = true;
    }
    private void Update() //매 프레임마다 호출되는 함수
    {
        if (GameStart == true && GameObject.Find("Player").GetComponent<Player>().gameover == false) //게임은 시작했고 게임오버 상태가 아니면, 밑에 있는 게임 시스템 구문 실행
        {
            curspawnDelay += Time.deltaTime; // 몬스터가 스폰하고 나서 얼만큼 시간이 지났는가
            if (WaveTime < WaveMaxTime) //웨이브가 끝날 때까지 현 웨이브 시간을 계속 증가
            {
                WaveTime += Time.deltaTime;
            }
            if ((curspawnDelay > maxDelay) && WaveTime < WaveMaxTime) //스폰 시간이 다되면 적 스폰
            {
                SpawnEnemy(); //적을 스폰하는 것은 오브젝트 풀링을 사용할 수 있었지만, 이 때 당시 지식적 한계로 구현x
                curspawnDelay = 0;
            }
            else if(WaveTime >= WaveMaxTime) //웨이브 시간이 끝나면, 다음 웨이브 준비 
            {
                if(waveend == false && (null == GameObject.FindWithTag("East") && null == GameObject.FindWithTag("West") && null == GameObject.FindWithTag("North") && null == GameObject.FindWithTag("South")))
                {
                    waveend = true;
                    ++Wave;
                    Invoke("RestTime", 1f); // 준비 시간
                }
            }
        }
    }

    void RestTime()
    {
        Wavenumber.text = Wave.ToString();
        NextWavenumber.text = "Wave " + Wave;
        WaveAnime.SetBool("WaveStart",true);
        Invoke("onWaveSound", 0.7f);
        Invoke("RestTimeEnd", 2f); //준비시간이 끝나면 준비시간 끝이라는 매서드 호출
    }
    void RestTimeEnd() //준비 시간이 끝나면, 다시 다음 웨이브 시작
    {
        WaveAnime.SetBool("WaveStart", false); 
        if (Wave % 5 == 0) //웨이브에 따라 웨이브 지속시간이 변경되는 것을 구현 (지속시간의 정도는 낮은 보통, 밤은 김, 새벽은 짧음)
        {
            tempMaxTime += 5f;
            WaveMaxTime = tempMaxTime;
            WaveMaxTime -= 5f;
        }
        else if ((Wave + 1) % 5 == 0)
        {
            WaveMaxTime = tempMaxTime;
            WaveMaxTime += 5f;
        }
        else if ((Wave + 4) % 5 == 0 || (Wave + 3) % 5 == 0)
        {
            WaveMaxTime = tempMaxTime;
        }
        else if ((Wave + 2) % 5 == 0)
        {
            tempMaxTime = WaveMaxTime;
            WaveMaxTime -= 5f;
        }
        if (maxDelay > 1.5f)
        {
            maxDelay -= 0.05f; // 몬스터 스폰 딜레이 점차 감소
        }
        Invoke("NextWaveStart", 2f);
    }

    void NextWaveStart()
    {
        WaveTime = 0;
        waveend = false;
    }

    void SpawnEnemy() // 몬스터 스폰 시 4방향 중 랜덤한 곳에서 스폰
    {
        if(Wave < 5)
        {
            ranEnemy = Random.Range(1, 3);
        }
        else if(Wave >= 5 && Wave < 10)
        {
            ranEnemy = Random.Range(1, 4);
        }
        else if(Wave >= 10)
        {
            ranEnemy = Random.Range(0, 4);
        }

        int ranSpawnPoint = Random.Range(0, 4);

        if(ranSpawnPoint == 0) //각 스폰 위치에 대한 몬스터 오브젝트의 로테이션 값, 애니메이션, 포지셔닝 조정
        {
            if (ranEnemy == 0)
            {
                Instantiate(E_Enemy[ranEnemy], KingDooSpawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
            else
            {
                Instantiate(E_Enemy[ranEnemy], spawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
        }
        else if (ranSpawnPoint == 1)//서쪽
        {
            if (ranEnemy == 0)
            {
                Instantiate(W_Enemy[ranEnemy], KingDooSpawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
            else
            {
                Instantiate(W_Enemy[ranEnemy], spawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
        }
        else if (ranSpawnPoint == 2)//북쪽
        {
            if (ranEnemy == 0)
            {
                Instantiate(N_Enemy[ranEnemy], KingDooSpawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
            else
            {
                Instantiate(N_Enemy[ranEnemy], spawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
        }
        else if (ranSpawnPoint == 3)//남쪽
        {
            if (ranEnemy == 0)
            {
                Instantiate(S_Enemy[ranEnemy], KingDooSpawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
            else
            {
                Instantiate(S_Enemy[ranEnemy], spawnPoint[ranSpawnPoint].position, spawnPoint[ranSpawnPoint].rotation);
            }
        }
    }

    public void GameOver() // 게임오버 되었을 때
    {
        IngameGroup.blocksRaycasts = false;
        IngameGroup.interactable = false;
        if (Wave > BestWave)
        {
            PlayerPrefs.SetInt("BestScore", Wave);
        }
        temp = PlayerPrefs.GetInt("NightPotion", 0);
        PlayerPrefs.SetInt("NightPotion", temp + UsingItemClass[0].NightC);
        temp = PlayerPrefs.GetInt("ProtectShield", 0);
        PlayerPrefs.SetInt("ProtectShield", temp + UsingItemClass[1].ShieldC);
        temp = PlayerPrefs.GetInt("HealPotion", 0);
        PlayerPrefs.SetInt("HealPotion", temp + UsingItemClass[2].HealC);
        Invoke("GameoverWindow", 0.5f);
    }
    void GameoverWindow() //게임 오버 창 띄위기
    {
        Ingame.color = new Color32(0, 0, 0, 100);
        GameOveranime.SetBool("isGameOver", true);
        Invoke("ShowWindow", 2.5f);
    }
    void ShowWindow() 
    {
        RewardWindow.alpha = 1;
        RewardWindow.blocksRaycasts = true;
        RewardWindow.interactable = true;
        Rewardanime.SetBool("isgameover", true);
        UISoundmanager.PlaySound(UISound[1]);
        StartCoroutine("CountKill");
    }
    IEnumerator CountKill() //얼마나 많은 몬스터를 쓰러뜨렸는 지 카운트하고 그에 맞는 보상 계산 
    {
        yield return null;
        
        DCount = GameObject.Find("Player").GetComponent<Player>().DoongKill;
        SCount = GameObject.Find("Player").GetComponent<Player>().SnaikyKill;
        GCount = GameObject.Find("Player").GetComponent<Player>().GbooKill;
        KCount = GameObject.Find("Player").GetComponent<Player>().KingDooKill;
        RewardGold = DCount * 1 + SCount * 2 + GCount * 3 + KCount * 5 + Wave * 10;
        MyGold = PlayerPrefs.GetInt("Gold", 0);
        MyGold += RewardGold;
        PlayerPrefs.SetInt("Gold", MyGold); //보상으로 받은 골드를 플레이어 데이터 값에 저장

        SkipBtnGroup.alpha = 1; // 보상 창이 나올 때 지루하신 플레이어를 위해 스킵 버튼 생성
        SkipBtnGroup.blocksRaycasts = true;
        SkipBtnGroup.interactable = true;

        UISoundmanager.PlaySound(UISound[2]);
        yield return new WaitForSeconds(1f);
        Title.text = "웨이브";
        BestWaveCount.text = BestWave.ToString();

        ScoreGroup.alpha = 1;
        ScoreGroup.blocksRaycasts = true;
        ScoreGroup.interactable = true;
        Scoreanime.SetBool("ShowScore", true);
        UISoundmanager.PlaySound(UISound[1]);
        yield return new WaitForSeconds(1f);

        for(int i=0;i <= Wave; i++)
        {
            UISoundmanager.PlaySound(UISound[0]);
            WaveCount.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
            if (isTouch == true)
            {
                isTouch = false;
                WaveCount.text = Wave.ToString();
                break;
            }
        }
        if(Wave > BestWave) //최고 웨이브 갱신 시 나오는 창
        {
            yield return new WaitForSeconds(0.5f);
            BestWaveanime.SetBool("isRenewal", true);
            UISoundmanager.PlaySound(UISound[3]);
        }

        yield return new WaitForSeconds(1f);
        Scoreanime.SetBool("ShowScore", false);
        UISoundmanager.PlaySound(UISound[2]);
        yield return new WaitForSeconds(1f);
        Title.text = "스코어";
        AccountGroup.alpha = 1;
        AccountGroup.blocksRaycasts = true;
        AccountGroup.interactable = true;
        Accountanime.SetBool("isAccount", true);
        UISoundmanager.PlaySound(UISound[1]);
        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= DCount; i++) // 보상 구성 설명
        {
            if (DCount != 0)
            {
                UISoundmanager.PlaySound(UISound[0]);
            }
            ADoong.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
            if (isTouch == true)
            {
                isTouch = false;
                ADoong.text = DCount.ToString();
                break;
            }
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i <= SCount; i++)
        {
            if (SCount != 0)
            {
                UISoundmanager.PlaySound(UISound[0]);
            }
            ASnailky.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
            if (isTouch == true)
            {
                isTouch = false;
                ASnailky.text = SCount.ToString();
                break;
            }
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i <= GCount; i++)
        {
            if (GCount != 0)
            {
                UISoundmanager.PlaySound(UISound[0]);
            }
            AGboo.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
            if (isTouch == true)
            {
                isTouch = false;
                AGboo.text = GCount.ToString();
                break;
            }
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i <= KCount; i++)
        {
            if (KCount != 0)
            {
                UISoundmanager.PlaySound(UISound[0]);
            }
            AKingDoo.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
            if (isTouch == true)
            {
                isTouch = false;
                AKingDoo.text = KCount.ToString();
                break;
            }
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i <= Wave; i++)
        {
            UISoundmanager.PlaySound(UISound[0]);
            AWave.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
            if (isTouch == true)
            {
                isTouch = false;
                AWave.text = Wave.ToString();
                break;
            }
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i <= RewardGold; i++)
        {
            UISoundmanager.PlaySound(UISound[0]);
            AGold.text = i.ToString();
            yield return new WaitForSeconds(0.01f);
            if (isTouch == true)
            {
                isTouch = false;
                AGold.text = RewardGold.ToString();
                break;
            }
        }
        if (GoldTwiceCount == 1)
        {
            yield return new WaitForSeconds(0.1f);
            GoldTwiceT.color = new Color32(250, 202, 63, 255);
            yield return new WaitForSeconds(0.1f);
            for (int i = RewardGold; i <= RewardGold * 2; i++)
            {
                UISoundmanager.PlaySound(UISound[0]);
                AGold.text = i.ToString();
                yield return new WaitForSeconds(0.01f);
                if (isTouch == true)
                {
                    isTouch = false;
                    AGold.text = (RewardGold * 2).ToString();
                    break;
                }
            }
            MyGold += RewardGold;
            PlayerPrefs.SetInt("Gold", MyGold);
        }
        SkipBtnGroup.alpha = 0;
        SkipBtnGroup.blocksRaycasts = false;
        SkipBtnGroup.interactable = false; // 스킵 버튼 비활성화
        yield return new WaitForSeconds(0.5f);
        LobbyBtnGroup.alpha = 1;
        LobbyBtnGroup.blocksRaycasts = true;
        LobbyBtnGroup.interactable = true; //로비로 가는 버튼 활성화
    }
}
