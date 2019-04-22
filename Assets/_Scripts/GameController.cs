using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        gameOver = false;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }


    private void Update()
    {
        if(restart )
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver )
            {
                restartText.text = "Press 'R' for Restart!";
                restart = true;
                break;
            }
        }
    }


    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text  = "Score:" + score.ToString();
    }


    public void GameOver()
    {
        gameOverText.text = "<b>Game Over!</b>";
        gameOver = true;
    }
}
