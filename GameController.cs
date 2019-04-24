using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GameObject Player;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text bombText;

    private bool gameOver;
    private bool restart;
    public bool won;
    private int score;
    private float bomb;
    public AudioSource[] sound;
    public AudioSource winSound;
    public AudioSource dieSound;

    void Start()
    {
        gameOver = false;
        restart = false;
        won = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        sound = GetComponents< AudioSource>();
        winSound = sound[1];
        dieSound = sound[2];
    }

    void Update()
    {

        if (gameOver == false && won == false)
        {
            bombText.text = "Bombs: " + (Player.GetComponent<PlayerController>().bomb);
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'O' for Restart";
                restart = true;
                break;
            }

            if (won)
            {
                restartText.text = "Press 'O' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100) {
            winSound.Play();
            won = true;
            winText.text = "Game created by Temprian Zaliauskas!  You Win!";
        }
    }

    public void GameOver()
    {
        if (won == false)
        {
            dieSound.Play();
            gameOverText.text = "Game Over!";
            gameOver = true;
        }
    }
}