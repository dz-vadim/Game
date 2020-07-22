using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int Score;
    public static int countBlock;

    public GameObject PauseMenu;
    public GameObject GameMenu;
    public TextMesh TextLevel;
    private static int level = 1;


    void Start()
    {
        Score = 0;
        TextLevel.text = $"Level {level}";
        countBlock = GameObject.FindGameObjectsWithTag("Block").Length;
    }
 

    void Update()
    {
        if (countBlock == 0)
        {
            NextLevel();
        }
    }

    public void Play()
    {
        PauseMenu.SetActive(false);
        GameMenu.SetActive(true);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        GameMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EnemyMove.speedMove *= 1.5f;
        level++;
    }
}
