using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Score;
    public static int countBlock;

    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject ExitButton;
    public Text PlayButtonText;
    public TextMesh TextLevel;

    private GameObject _player;
    private static int level = 1;


    void Start()
    {
        Score = 0;
        TextLevel.text = $"Level {level}";
        countBlock = GameObject.FindGameObjectsWithTag("Block").Length;
        _player = GameObject.FindWithTag("Player");
        if (level == 1)
        {
            PlayButtonText.text = "Start play";
            Pause();
        }
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
        PlayButtonText.text = "Resume";
        _player.SetActive(true);
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
   
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        ExitButton.SetActive(false);
#else
         Application.Quit();
#endif
    }
    public void Pause()
    {
        _player.SetActive(false);
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EnemyMove.speedMove *= 1.5f;
        level++;
    }
}
