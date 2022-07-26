using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager
{
    private static int currentGold = 100;
    public static int enemyPrize = 30;
    public GoldManager()
    {
    }
    public static int GetGold()
    {
        return currentGold;
    }
    public static void SetGold(int amount)
    {
        currentGold = amount;
    }
    public static void AddGold(int amount)
    {
        currentGold += amount;
    }
    public static void DecreaseGold(int amount)
    {
        currentGold -= amount;
    }
}
