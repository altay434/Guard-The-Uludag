using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public bool isPlaying = false;
    public bool isDone = false;
    public List<WaveEvent> events = new List<WaveEvent>();
    
    public bool IsThereEnemy()
    {
        GameObject gameobject = GameObject.Find("enemy(Clone)");
        if(gameobject != null)
        {
            return true;
        }
        return false;
    }
    public void StartWave()
    {
        isPlaying = true;
        if (events.Count != 0)
        {
            events[0].StartEvent();
        }
        
    }
    void Start()
    {
        StartWave();
    }
    void Update()
    {
        if (!isPlaying)
        {
            return;
        }
        if (!events[0].RunEvent())
        {
            events.RemoveAt(0);
            if(events.Count == 0)
            {
                isDone = true;
            }
            else
            {
                events[0].StartEvent();
            }
            //StartWave(); // Eðer sonsuz döngü istiyorsan bunu çalýþtýr
        }
    }
    [System.Serializable]
    public class WaveEvent
    {
        public float duration;
        public List<Spawners> spawners;
        private float startTime;
        public void StartEvent()
        {
            startTime = Time.time;
            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].currentAmount = 0;
            }
        }
        public bool RunEvent()
        {
            if (duration == 0.0f && spawners.Count == 0) { return false; }
            else if (Time.time - startTime > duration && duration != 0.0f) { return false; }

            for (int i = 0; i < spawners.Count; i++)
            {
                if (spawners[i].currentAmount < spawners[i].enemyAmount)
                {
                    spawners[i].Spawn();
                }
            }
            return true;
        }
        [System.Serializable]
        public class Spawners
        {
            public GameObject enemyPrefab;
            public GameObject spawner;
            public int enemyAmount;
            public float interval = 1f;
            public int currentAmount = 0;

            private float lastTime;
            public void Spawn()
            {
                if (Time.time - lastTime > interval)
                {
                    
                    Instantiate(enemyPrefab, spawner.transform.position, Quaternion.identity);
                    currentAmount++;
                    lastTime = Time.time;
                }
            }
        }
    }
}
