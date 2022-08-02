using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaTowerFire : MonoBehaviour
{
    [Header("Tower Stats")]
    public float range;
    public float interval;
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
    private void Fire()
    {

        Collider2D[] collides = Physics2D.OverlapCircleAll(this.transform.position, range);
        for (int i = 0; i < collides.Length; i++)
        {
            if (collides[i].CompareTag("enemy"))
            {
                collides[i].GetComponent<EnemyScript>().health -= TowerClass.areaTowerDamage;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
}
