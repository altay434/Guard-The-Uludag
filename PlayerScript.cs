using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public int health;
    private void Start()
    {
        health = 100;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            health -= 30;
            Destroy(collision.gameObject);
        }
    }
}
    
