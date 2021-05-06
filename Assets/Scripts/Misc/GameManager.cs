using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int enemyKillCount = 0;

    public float LoadTimer = 8f;
    private bool rdytoload = true;
    private void Start()
    {
        enemyKillCount = 0;
    }

    public void QUITGAME()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
        EnemySpawner.bossIsSpawned = false;
        enemyKillCount = 0;
        Player.playerHP = 20;
    }


    public void EndGame()
    {
        EnemySpawner.bossIsSpawned = false;
        enemyKillCount = 0;
       
        uiScript.gameIsLost = true;
        if (rdytoload) StartCoroutine(MenuLoadTimer("PlayScene",1f));
    }
    public void gameWin()
    {
        //  EnemySpawner.bossIsSpawned = false;
        uiScript.gameIsWon = true;
        FindObjectOfType<audio>().playAudio("victoryMusic");
       if(rdytoload) StartCoroutine(MenuLoadTimer("MainMenu",LoadTimer));

    }
    IEnumerator MenuLoadTimer(string sceneName,float time) {
        rdytoload = false;
        yield return new WaitForSecondsRealtime(time);
        rdytoload = true;
        enemyKillCount = 0;
        EnemySpawner.bossIsSpawned = false;
        // load main menu here 
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneName);
        Player.playerHP = 20;
        Boss.hp = 30;
        uiScript.gameIsLost = false;

    }




}
