using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    
    //public SceneFader sceneFader;
    void Start()
    {
        isGameOver = false ;
    }
    void Update()
    {
        if (isGameOver)
            return;
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if(PlayerStats.Lives <= 0f)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        isGameOver = true;
        completeLevelUI.SetActive(true);
    }
}
