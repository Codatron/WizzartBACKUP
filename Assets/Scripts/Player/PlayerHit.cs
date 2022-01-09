using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHit : MonoBehaviour
{
    //List for sound when hit
    List<AudioClip> hitSoundList = new List<AudioClip>();
    public AudioClip Sound1;
    public AudioClip Sound2;
  

    //Code for random sprite when taking hit
    List<GameObject> phrasesList = new List<GameObject>();
    
    public GameObject phrases1;
    public GameObject phrases2;
    public GameObject phrases3;

    public GameObject deadGun;
    public Sprite playerCorpseSprite;
    public AudioSource speaker;
    public GameObject gameOverScreen;
    public float invincibilityTime = 1.5f;
    public static bool isGameOver;
    
    private GameObject managerGame;
    private PlayerHealthController refHealthController;
    private SpriteRenderer playerSpriteRenderer;
    private bool invincible = false;
    private int playerHit;
    private int hpLost = 1;
    public int playerHealthMax = 20;
    public int playerHealthCurrent;
    public Integer2 HealthRef;
    public RuntimeAnimatorController deathController;

    public GameObject exPoint;

    public int phrasesIndex;
    public int soundIndex;

    private void Awake()
    {
        isGameOver = false;
        phrasesIndex = UnityEngine.Random.Range(0, 3);
        soundIndex = UnityEngine.Random.Range(0, 2);
    }

    void Start()
    {
        managerGame = GameObject.FindGameObjectWithTag("ManagerGame");
        refHealthController = managerGame.GetComponent<PlayerHealthController>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        playerHit = 0;
        playerHealthCurrent = playerHealthMax;

        //Add to sprit when hit list
        
        phrasesList.Add(phrases1);
        phrasesList.Add(phrases2);
        phrasesList.Add(phrases3);

        //Add sound when hit to list
        hitSoundList.Add(Sound1);
        hitSoundList.Add(Sound2);
        
    }
   

    void TakeDamage(int hpLost)
    {
        playerHealthCurrent -= hpLost;
        refHealthController.SetCurrentHealth(playerHealthCurrent);
    }

    void KillMePlayer()
    {
	    
        GameObject playerCorpse = new GameObject("playerCorpse");
        SpriteRenderer playerCorpseRenderer = playerCorpse.AddComponent<SpriteRenderer>();
        playerCorpse.transform.position = transform.position;
        playerCorpseRenderer.sprite = playerCorpseSprite;
        playerCorpseRenderer.flipX = playerSpriteRenderer.flipX;
      //  playerCorpseRenderer.transform.localScale = transform.localScale;
        Animator anim = playerCorpse.AddComponent<Animator>();
        anim.runtimeAnimatorController = deathController;

        anim.Play("Gundeath");
        isGameOver = true;
        Destroy(gameObject);
    }
    //void gameOver()
    //{
    //    if (playerHit >= 20)
    //    {
    //        Time.timeScale = 0f;
    //    }
    //}

    private void Update()
    {
        HealthRef.integerA = playerHealthCurrent;
        HealthRef.integerB = playerHealthMax;

        if (playerHealthCurrent <= 0)
        {
            KillMePlayer();

            float timeLimit = 1.5f;

            if (Time.time > timeLimit)
            {
                Time.timeScale = 0f;
                gameOverScreen.SetActive(true);
            }
        }

        if (isGameOver)
        {
            StartCoroutine("GameOver");

        }
    }


    public IEnumerator GameOver ()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        gameOverScreen.SetActive(true);

    }

 
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!invincible)
        {
            if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("EnemyLipsBig") || other.gameObject.CompareTag("EnemyLipsSmall") || other.gameObject.CompareTag("EnemyLollipopGirlPink") || other.gameObject.CompareTag("PaintEnemy"))
            {
                getHit(phrasesIndex, soundIndex);      
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invincible)
        {
            if (other.gameObject.CompareTag("LollipopBlue") || other.gameObject.CompareTag("LollipopPink") || other.gameObject.CompareTag("PaintRay")|| other.gameObject.CompareTag("PaintBlob"))
            {
                getHit(phrasesIndex, soundIndex);
            }
        }
    }

    private void getHit(int phrasesIndex, int soundIndex)
    {
        playerHealthCurrent--;
        StartCoroutine(PlayerTakeDamageColour());

        TakeDamage(hpLost);

        StartCoroutine(Invulnerability());

        Vector3 prefab = new Vector3(exPoint.transform.position.x, exPoint.transform.position.y);
        GameObject hitPrefab = Instantiate(phrasesList[phrasesIndex], prefab, Quaternion.identity);
        Destroy(hitPrefab, 0.5f);

        speaker.PlayOneShot(hitSoundList[soundIndex]);

        //TODO lagg till så att ett ljud får spelas klart innan nästa
    }

    IEnumerator PlayerTakeDamageColour()
    {
        playerSpriteRenderer = GameObject.FindGameObjectWithTag("PlayerSpriteRenderer").GetComponent<SpriteRenderer>();
        //rend = GetComponent<SpriteRenderer>();
        playerSpriteRenderer.color = Color.magenta;
        yield return new WaitForSeconds(0.05f);
        playerSpriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        playerSpriteRenderer.color = Color.magenta;
        yield return new WaitForSeconds(0.05f);
        playerSpriteRenderer.color = Color.white;
    }

    IEnumerator Invulnerability()
    {       
        invincible = true;
        playerSpriteRenderer.color = Color.magenta;
        yield return new WaitForSeconds(invincibilityTime);
        playerSpriteRenderer.color = Color.white;
        invincible = false; 

        //TO DO FÄRG ANDRA FUNKAR EJ
    }
}
