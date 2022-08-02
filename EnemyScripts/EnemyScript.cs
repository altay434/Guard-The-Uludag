using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public float speed;
    void Start()
    {
        health = 100;  // Farkl� d��man t�rlerine tagler ile farkl� de�erler atayabiliriz.
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
            GoldManager.AddGold(GoldManager.enemyPrize);
        }
    }
}
