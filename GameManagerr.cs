using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerr : MonoBehaviour
{
    public bool isFinished = false;
    public bool isWin = false;
    public GameObject gameOverUI;
    public GameObject successUI;
    private GameObject player;
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isWin == true && isFinished == true)
        {
            Time.timeScale = 0;
            successUI.SetActive(true);
            
        }
        if (isWin == false && isFinished == true)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
        if(player.GetComponent<PlayerScript>().health <= 0)
        {
            isFinished = true;
            isWin = false;
            return;
        }
        if(GameObject.Find("EnemySpawner").GetComponent<WaveCreator>().isDone && !GameObject.Find("EnemySpawner").GetComponent<WaveCreator>().IsThereEnemy()) 
        {
            isFinished = true;
        }
        if (isFinished == true && player.GetComponent<PlayerScript>().health > 0)
        {
            isWin = true;

        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


