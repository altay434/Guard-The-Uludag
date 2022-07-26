using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int waveCounter = 0;
    public int enemyCounter = 0;
    public float spawnSpeed = 2;
    public GameObject[] enemyTypes;
    public GameObject enemySpawner;
    public GameObject spawnedEnemy;
    GameObject waveText;
    int enemyAmount = 5;
    bool canSpawn = true;
    bool isWaveFinished = false;

    public void Start()
    {
        waveText = GameObject.Find("wave");
    }
    void Update()
    {
        Spawn();
        if(waveCounter == 9)       
        {
            
            GameObject.Find("GameManager").GetComponent<GameManagerr>().isFinished = true;
        }
    }
    
    IEnumerator waitForWave()
    {
        enemyCounter = 0;
        yield return new WaitForSeconds(10);
        EnemyClass.speed += 0.5f;
        spawnSpeed = 10 / EnemyClass.speed;
        EnemyClass.health += 20;
        enemyAmount += 1;
        isWaveFinished = false ;
        StopAllCoroutines();
    }
    IEnumerator spawn()
    {
        Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], enemySpawner.transform.position, enemySpawner.transform.rotation);
        waveText.GetComponent<UnityEngine.UI.Text>().text = "Wave: " + (waveCounter+1).ToString();
        canSpawn = false;
        enemyCounter += 1;
        if(enemyCounter == enemyAmount) { isWaveFinished = true; waveCounter++; }
        yield return new WaitForSeconds(spawnSpeed);
        
        canSpawn = true;

    }
    void Spawn()
    {
        if (isWaveFinished)
        {
            StartCoroutine(waitForWave());
            
        }
        else if (canSpawn)
        {
            StartCoroutine(spawn());
        }
    }
}
