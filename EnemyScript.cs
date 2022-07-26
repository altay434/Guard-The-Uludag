using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    void Start()
    {
        health = EnemyClass.health;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        else if(collision.CompareTag("towerBomb")) 
        {
            health -= 50;
        }
        else if (collision.CompareTag("towerBullet"))
        {
            health -= 35;
        }
        else if (collision.CompareTag("Mine"))
        {
            health -= 90;
        }
    }
    
}
