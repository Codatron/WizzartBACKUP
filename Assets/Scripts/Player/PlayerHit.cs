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
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;

    public AudioSource speaker;
    public GameObject gameOverScreen;
    public float invincibilityTime = 1.5f;
    public static bool isGameOver;
    
    private GameObject managerGame;
    private PlayerHealthController refHealthController;
    private SpriteRenderer rend;
    private bool invincible = false;
    private int playerHit;
    private int hpLost = 1;
    private int playerHealthMax = 5;
    private int playerHealthCurrent;

    private void Awake()
    {
        isGameOver = false;
    }

    void Start()
    {
        managerGame = GameObject.FindGameObjectWithTag("ManagerGame");
        refHealthController = managerGame.GetComponent<PlayerHealthController>();
        rend = GetComponent<SpriteRenderer>();

        refHealthController.SetMaxHealth(playerHealthMax);

        playerHit = 0;

        playerHealthCurrent = playerHealthMax;

        //Add to sprit when hit list
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);

        //Add sound when hit to list
        hitSoundList.Add(Sound1);
        hitSoundList.Add(Sound2);
        hitSoundList.Add(Sound3);
        hitSoundList.Add(Sound4);
        hitSoundList.Add(Sound5);
    }

    //andra farg vid skada
    IEnumerator color()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        rend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rend.color = Color.white;
    }

    void TakeDamage(int hpLost)
    {
        playerHealthCurrent -= hpLost;
        refHealthController.SetCurrentHealth(playerHealthCurrent);
    }
    void gameOver()
    {
        if (playerHit > 4)
        {
            Time.timeScale = 0f;
            isGameOver = true;
        }
    }
    private void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //For random play/sprite
        int prefabIndex = UnityEngine.Random.Range(0, 3);
        int soundIndex = UnityEngine.Random.Range(0, 4);

        if (!invincible)
        {
            if (other.gameObject.CompareTag("EnemyLollipopGirlBlue") || other.gameObject.CompareTag("LollipopBlue") || other.gameObject.CompareTag("EnemyLips") || other.gameObject.CompareTag("LollipopPink") || other.gameObject.CompareTag("EnemyLollipopGirlPink"))
            {
                playerHit++;
                StartCoroutine(color());

                //refHealthController.
                //PlayerHP(hpLost);

                TakeDamage(hpLost);

                //For att inte ta skada
                StartCoroutine(Invulnerability());

                //random prefab for skada
               GameObject hitPrefab = Instantiate(prefabList[prefabIndex], transform.position, Quaternion.identity);
                Destroy(hitPrefab, 0.5f);

                //Play random sound hit
                speaker.PlayOneShot(hitSoundList[soundIndex]);

                //TODO lagg till så att ett ljud får spelas klart innan nästa

                if (playerHit > 4)
                {
                    Time.timeScale = 0f;
                    isGameOver = true;
                }
            }
        }
    }

    // so that the player dont take damage after hit
    IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }
}
