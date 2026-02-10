using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int enemyIsAlive = 0;
    public int round = 0;
    public GameObject[] enemySpawnPositions;
    public GameObject[] enemyPrefab;
    public TMP_Text roundText;
    public GameObject endGame;
    public TMP_Text score;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.gameplayMusic);
    }
    private void Update()
    {
        if (enemyIsAlive == 0)
        {
            round++;
            roundText.text = "Round : " + round.ToString();
            NextWave(round);
        }
    }
    public void NextWave(int round)
    {
        for (var x = 0; x < round; x++)
        {
            GameObject SelectedSpawnPos = enemySpawnPositions[Random.Range(0, enemySpawnPositions.Length)];
            GameObject selectedEnemyPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            Instantiate(selectedEnemyPrefab, SelectedSpawnPos.transform.position, Quaternion.identity);
            enemyIsAlive++;

        }
    }
    public void EndTheGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        AudioManager.instance.PlayMusic(AudioManager.instance.gameOverMusic);

        endGame.SetActive(true);
        score.text = round.ToString();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

