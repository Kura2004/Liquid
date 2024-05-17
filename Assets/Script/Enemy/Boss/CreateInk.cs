using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInk : MonoBehaviour
{
    public GameObject ink;
    public Transform ink_point;
    public float interval;
    public float destroy_time;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            time = 0;
            SpawnEnemy();
        }

    }

    // Update is called once per frame
    public void SpawnEnemy()
    {
        GameObject o = Instantiate(ink, ink_point.position, Quaternion.identity);
        Destroy(o, destroy_time);
    }
}
