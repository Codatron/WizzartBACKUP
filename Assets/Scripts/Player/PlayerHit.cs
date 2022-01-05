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
    public AudioClip Sound3;
    public AudioClip Sound4;
    public AudioClip Sound5;

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

    private void Awake()
    {
        isGameOver = false;
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
        hitSoundList.Add(Sound3);
        hitSoundList.Add(Sound4);
        hitSoundList.Add(Sound5);
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
    void gameOver()
    {
        if (playerHit >= 20)
        {
            Time.timeScale = 0f;
        }
    }

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
            //Destroy(gameObject);
            gameOverScreen.SetActive(true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("BossScene");
            MusicSound.PlayBossMusic();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //For random play/sprite
        int phrasesIndex = UnityEngine.Random.Range(0, 3);
        int soundIndex = UnityEngine.Random.Range(0, 4);

        if (!invincible)
        {
            if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("LollipopBlue") || other.gameObject.CompareTag("EnemyLipsBig") || other.gameObject.CompareTag("EnemyLipsSmall") || other.gameObject.CompareTag("LollipopPink") || other.gameObject.CompareTag("EnemyLollipopGirlPink") || other.gameObject.CompareTag("PaintBlob") || other.gameObject.CompareTag("PaintRay") || other.gameObject.CompareTag("PaintEnemy"))
            {
                playerHit++;
                StartCoroutine(PlayerTakeDamageColour());

                TakeDamage(hpLost);

                //For att inte ta skada
                StartCoroutine(Invulnerability());

                //random prefab for skada
                Vector3 prefab = new Vector3(exPoint.transform.position.x, exPoint.transform.position.y);
                GameObject hitPrefab = Instantiate(phrasesList[phrasesIndex], prefab, Quaternion.identity);
                Destroy(hitPrefab, 0.5f);

                //Play random sound hit
                speaker.PlayOneShot(hitSoundList[soundIndex]);

                //TODO lagg till s� att ett ljud f�r spelas klart innan n�sta

                //if (playerHit >= 10)
                //{
                //    Time.timeScale = 0f;
                //    isGameOver = true;
                //}
            }
        }
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
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }
}
