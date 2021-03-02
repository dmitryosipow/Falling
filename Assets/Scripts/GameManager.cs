using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Фрукты")]
    public GameObject positivePickup;
    public GameObject negativePickup;
    public GameObject livePickup;
    /*private void Awake()
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }

        }
    }*/

    [Header("Good chance")]
    public float goodPercent;
    [Header("Bad chance")]
    public float badPercent;
    [Header("Live chance")]
    public float livePercent;

    [Header("Pickups appear delay")]
    public float positiveTimeout;
    public float negativeTimeout;
    public float liveTimeout;

    public Text scoreText;
    public ScoreSO scoreSO;

    int scoreNumber = 0;
    int currentHealth = 3;
    public HealthBar healthBar;
    public bool isStarted;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        if (!isStarted)
        {
            SetScore(scoreSO.points);
            return;
        }
        scoreSO.Reset();
        SetScore(scoreNumber);
        RestartLevel();
        if (isStarted)
        {
            StartCoroutine(DownObj(positivePickup, positiveTimeout));
            StartCoroutine(DownObj(negativePickup, negativeTimeout));
            StartCoroutine(DownObj(livePickup, liveTimeout));
        }
    }

    public void UpdateScore(int score)
    {
        scoreNumber+= score;
        SetScore(scoreNumber);
    }

    void SetScore(int score)
    {
        if(scoreText == null)
        {
            return;
        }

        scoreText.text = score.ToString();
        scoreSO.SetScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChangeHealth(int delta)
    {
        print("curr health " + currentHealth);
        currentHealth += delta;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Finish");
        }
    }

    IEnumerator DownObj(GameObject pickup, float firstTime)
    {
        while (isStarted)
        {
            float rand = Random.Range(0, 101);
            if (rand <= goodPercent)
            {
                CreatePickup(pickup);
            }
            yield return new WaitForSeconds(firstTime);
        }
    }

    void CreatePickup(GameObject pickup)
    {
        Instantiate(pickup, new Vector3(Random.Range(-8f, 8f), 5f, 0f), Quaternion.identity);
    }

    public void RestartLevel()
    {
        currentHealth = 3;
        if (healthBar)
        {
            healthBar.currentHealth = currentHealth;
        }
    }
}
