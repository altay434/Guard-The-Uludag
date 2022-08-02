using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private List<Collider2D> enemies; 
    private GameObject target;
    private int bombSpeed;
    private float minimalEnemyDistance;
    private float distanceToTarget;

    void Start()
    {
        minimalEnemyDistance = float.MaxValue;
        bombSpeed = 80;
    }

    void Update()
    {
        enemies = GetComponentInParent<bombTowerFire>().GetEnemies();
        foreach (Collider2D enemy in enemies)
        {
            distanceToTarget = enemy.GetComponent<EnemyPathTracking>().DistanceToPlayer();
            if (distanceToTarget < minimalEnemyDistance)
            {
                target = enemy.gameObject;
                minimalEnemyDistance = distanceToTarget;
            }
        }
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (transform.position != target.transform.position) 
        {
            Vector2 dir = Vector2.MoveTowards(transform.position,target.transform.position,bombSpeed*Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(dir);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().health -= TowerClass.areaTowerDamage;
            Destroy(gameObject);
        }
    }
}
