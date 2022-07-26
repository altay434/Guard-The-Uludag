using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombTowerFire : MonoBehaviour
{
    public GameObject tower; // This object defined in unity
    public GameObject bomb; // This too
    public List<GameObject> enemies;
    public bool canFire = false;
    public int counter = 0;

    float fireSpeed = 1f;

    void Update()
    {
        StartFireRoutine();
    }

    private void StartFireRoutine()
    {
        if (canFire)
        {
            StartCoroutine(Fire());
        }
        if (enemies.Count == 0)
        {
            StopAllCoroutines();
            counter = 0;
        }
    }

    IEnumerator Fire()
    {
        
        GameObject firedBullet = Instantiate(bomb, tower.transform.position, tower.transform.rotation);
        firedBullet.transform.SetParent(tower.transform, true);
        
        canFire = false;
        yield return new WaitForSeconds(fireSpeed);
        canFire = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemies.Add(collision.gameObject);
            if(counter == 0)
            {
                canFire = true;
                counter++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemies.Remove(collision.gameObject);
        }
    }
        

}
