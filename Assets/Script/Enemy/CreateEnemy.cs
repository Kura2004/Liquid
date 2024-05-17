using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemy_point;
    public float interval = 3.0f;
    public float destroy_time;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.1f, interval);
    }

    // Update is called once per frame
    public void SpawnEnemy()
    {
        GameObject o = Instantiate(enemy, enemy_point.position, Quaternion.identity);
        Destroy(o, destroy_time);
    }
}
