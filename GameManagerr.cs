using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerr : MonoBehaviour
{
    GameObject player;
    public bool isFinished = false;
    public bool isWin = false;
    public GameObject gameOverUI;
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.Find("player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerScript>().health <= 0)
        {
            isFinished = true;
            isWin = false;
        }
        if(isFinished == true && player.GetComponent<PlayerScript>().health > 0)
        {
            isWin = true;
        }
        if(isWin == true && isFinished == true)
        {
            //Time.timeScale = 0;
            //gameOverUI.SetActive(true);
            
        }
        if(isWin == false && isFinished == true)
        {
            //Time.timeScale = 0;
            //gameOverUI.SetActive(true);
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}


