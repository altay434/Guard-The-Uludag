using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreator : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject selectionHover,selectionHover2;
    private bool isBuildMode = false;
    private int selectedTower;
    private int price;
   

    void Update()
    {
        if (isBuildMode)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit.collider == null || !hit.collider.CompareTag("empytTile"))
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                selectionHover.SetActive(false);
                selectionHover2.SetActive(true);
                selectionHover2.transform.position = new Vector2((float)(Mathf.RoundToInt(worldPosition.x+0.5f) - 0.5f), (float)(Mathf.RoundToInt(worldPosition.y + 0.5f) - 0.5f));
                if (Input.GetMouseButtonDown(0)) { selectionHover2.SetActive(false); isBuildMode = false; }
                return;
            }
            selectionHover.SetActive(true);
            selectionHover2.SetActive(false);
            selectionHover.transform.position = hit.collider.transform.position;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            PlaceTower(hit);
        }
    }
    void PlaceTower(RaycastHit2D hit)
    {
        if(hit.collider == null) { return; }
        if (hit.collider.CompareTag("empytTile") && GoldManager.GetGold() >= price && isBuildMode)
        {
            hit.collider.gameObject.SetActive(false);
            Instantiate(towers[selectedTower], hit.transform.position, Quaternion.identity);
            GoldManager.DecreaseGold(price);
            isBuildMode = false;
            selectionHover.SetActive(false);
            selectionHover2.SetActive(false);
        }
    }
    public void SelectBulletTower()
    {
        isBuildMode = true;
        price = TowerClass.bulletTowerPrice;
        selectedTower = 0;
    }
    public void SelectAreaTower()
    {
        isBuildMode = true;
        price = TowerClass.areaTowerPrice;
        selectedTower = 1;
    }
}
