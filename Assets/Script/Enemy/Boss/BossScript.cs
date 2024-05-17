using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
{
    private float time = 0;
    public static float wave_time;
    [SerializeField] float trigger_time;
    [SerializeField] float attack_time;
    public static Transform boss;

    private void Start()
    {
        boss = GetComponent<Transform>();
    }

    void Update()
    {

        time += Time.deltaTime;
        //Debug.Log("" + time);

        if (time > trigger_time)
            wave_set();

        if (time > attack_time)
        {
            time = 0;
            int select = (int)Random.Range(1.0f, 5.0f);
            Debug.Log("" + select);

            switch (select)
            {
                case 1:
                    GetComponent<BossAttack1>().enabled = true;
                    break;
                case 2:
                    GetComponent<BossAttack2>().enabled = true;
                    break;
                case 3:
                    GetComponent<BossAttack3>().enabled = true;
                    break;
                case 4:
                    GetComponent<BossAttack4>().enabled = true;
                    break;
            }

            GetComponent<BossScript>().enabled = false;
            GetComponent<Patrol>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CreateInk>().enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
        wave();
    }

    public static void wave_set()
    {
        wave_time = 0.5f;
    }

    public static void wave()
    {
        wave_time -= Time.deltaTime;
        if (wave_time > 0)
            boss.Translate(VectorAlpha.RandomVector3() * wave_time * 0.3f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            PlayerHp.Damage(1000);
            Debug.Log("HitBoss");
        }
    }
}
