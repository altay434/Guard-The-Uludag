using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaTowerFire : MonoBehaviour
{
    public GameObject tower; // This object defined in unity
    public List<GameObject> enemies;
    public bool canFire = false;
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
            tower.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    IEnumerator Fire()
    {

        tower.transform.GetChild(0).gameObject.SetActive(true);
        canFire = false;
        yield return new WaitForSeconds(0.2f);
        tower.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(fireSpeed - 0.2f);

        canFire = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            if (enemies.Count == 0) { canFire = true; }
            enemies.Add(collision.gameObject);
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
