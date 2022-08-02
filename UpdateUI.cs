using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    private GameObject goldText, bulletTowerPriceText, areaTowerPriceText;
    void Start()
    {
        goldText = GameObject.Find("goldText");
        bulletTowerPriceText = GameObject.Find("bulletTowerPrice");
        areaTowerPriceText = GameObject.Find("areaTowerPrice");
    }

    // Update is called once per frame
    void Update()
    {
        goldText.GetComponent<UnityEngine.UI.Text>().text = GoldManager.GetGold().ToString();
        bulletTowerPriceText.GetComponent<UnityEngine.UI.Text>().text = TowerClass.bulletTowerPrice.ToString();
        areaTowerPriceText.GetComponent<UnityEngine.UI.Text>().text = TowerClass.areaTowerPrice.ToString();
    }

    
}
