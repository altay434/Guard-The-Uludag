using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombTowerFire : MonoBehaviour
{
    [Header("Tower Stats")]
    public int range;
    public float interval;
    
    [Header("Tower Requirments")]
    public GameObject bombPrefab;

    private float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
       if(Time.time - startTime > interval)
        {
            Fire();
            startTime = Time.time;
        }
    }
    void Fire()
    {
        Collider2D[] collides = Physics2D.OverlapCircleAll(transform.position, range);
        for(int i = 0; i < collides.Length; i++)
        {
            if (!collides[i].CompareTag("enemy")) { continue; }
            Instantiate(bombPrefab, transform.position, Quaternion.identity,this.gameObject.transform);
            return;
        }
    }
    
    public List<Collider2D> GetEnemies()
    {
        Collider2D[] collides = Physics2D.OverlapCircleAll(transform.position, range);
        List<Collider2D> enemies = new List<Collider2D>();
        foreach (Collider2D enemy in collides)
        {
            if (!enemy.CompareTag("enemy")) { continue; }
            enemies.Add(enemy);
        }
        return enemies;
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
