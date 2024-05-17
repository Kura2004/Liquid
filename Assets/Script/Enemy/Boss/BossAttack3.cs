using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack3 : MonoBehaviour
{
    [SerializeField] float attack_interval = 0;
    float time;
    [SerializeField] Rigidbody rb;
    private Transform player;
    [SerializeField] float[] attack_speed;
    int attack_index = 0;
    private const float adjust = 0.1f;
    int hit_count = 0;

    private void Start()
    {
        time = attack_interval;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > attack_interval)
        {
            GetComponent<CreateInk>().enabled = true;
            time = 0;
            transform.position = new Vector3(transform.localPosition.x, 4.0f, transform.localPosition.z);
            hit_count++;
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.TransformDirection(Vector3.forward) * attack_speed[attack_index++], ForceMode.Acceleration);
        }

        if (time > attack_interval - adjust) 
        {
            GetComponent<CreateInk>().enabled = false;
            transform.Translate(VectorAlpha.RandomVector3() * 0.3f);
        }

        if (transform.position.y > 4.0f)
        {
            GetComponent<CreateInk>().enabled = false;
        }

        if (time * (hit_count + 1) > attack_interval * 3) 
        {
            time = attack_interval;
            hit_count = 0;
            attack_index = 0;
            GetComponent<BossAttack3>().enabled = false;
            GetComponent<BossScript>().enabled = true;
            GetComponent<Patrol>().enabled = true;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<CreateInk>().enabled = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<CreateInk>().enabled = false;
            PlayerHp.Damage(300);
            rb.velocity = transform.TransformDirection(Vector3.back) * 15.0f;
        }
    }
}
