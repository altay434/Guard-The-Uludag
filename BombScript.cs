using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject target;
    int bombSpeed;
    float minimalEnemyDistance;
    float distanceToTarget;

    void Start()
    {
        minimalEnemyDistance = float.MaxValue;
        bombSpeed = 80;
    }

    void Update()
    {
        
        enemies = this.transform.parent.gameObject.transform.GetComponent<bombTowerFire>().enemies;
        foreach (GameObject enemy in enemies)
        {
            distanceToTarget = enemy.GetComponent<EnemyPathTracking>().DistanceToPlayer();
            if (distanceToTarget < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToTarget;
            }
        }
        if (target == null)
        {
            Destroy(gameObject);
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
            Destroy(gameObject);
        }
    }
}
