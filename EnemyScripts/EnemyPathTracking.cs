using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathTracking : MonoBehaviour
{
    private Transform[] tracks;
    private int currentTrack;
    private float speed;
    void Start()
    {
        currentTrack = 0;
        tracks = GameObject.Find("TrackPoints").GetComponent<TrackPoints>().tracks;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<EnemyScript>().speed;
        StartFollowing();
    }

    private void StartFollowing()
    {
        if (transform.position != tracks[currentTrack].position)
        {
            Vector2 dir = Vector2.MoveTowards(transform.position, tracks[currentTrack].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(dir);
        }
        else
        {
            Debug.Log("TrackDegisti");
            currentTrack++;
        }
    }

    public float DistanceToPlayer()
    {
        float distance = 0;
        distance += Vector2.Distance(this.gameObject.transform.position, tracks[currentTrack].transform.position);
        for(int i = currentTrack + 1; i < tracks.Length - 1; i++)
        {
            distance += Vector2.Distance(tracks[i].transform.position, tracks[i+1].transform.position);
        }
        return distance;
    }

}