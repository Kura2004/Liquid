using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack2 : MonoBehaviour
{
    float time = 0;
    [SerializeField] GameObject rain;
    [SerializeField] int max_count;
    [SerializeField] float rain_rad;
    int rain_count;
    [SerializeField] float attack_interval;
    [SerializeField] Rigidbody rb;

    // Update is called once per frame
    void Update()
    {

        if (time > attack_interval)
        {
            Vector3 rain_point = transform.position + rain_rad * VectorAlpha.RandomVector3();
            rain_point.y = 30;
            GameObject RainShoot =
                Instantiate(rain, rain_point,
                Quaternion.identity) as GameObject;
            rain_count++;
            time = 0;
            
        }

        time += Time.deltaTime;
        if (time * (rain_count) > attack_interval * max_count) 
        {
            time = 0;
            rain_count = 0;
            GetComponent<BossAttack2>().enabled = false;
            GetComponent<BossScript>().enabled = true;
            GetComponent<Patrol>().enabled = true;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<CreateInk>().enabled = true;
            
        }
        rb.velocity = Vector3.zero;
    }
}
