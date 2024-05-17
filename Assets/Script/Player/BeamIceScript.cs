using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamIceScript : MonoBehaviour
{
    public GameObject explosion;
    private GameObject beam_point;
    private int slowed;
    [SerializeField] int attack_interval;
    private void Start()
    {
        beam_point = GameObject.FindWithTag("BeamPoint");
        slowed = 0;
    }
    private void Update()
    {
        transform.position = beam_point.transform.position;
        transform.rotation = beam_point.transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        slowed++;
        if (slowed % attack_interval == 1)
        {
            if (other.tag == "Enemy")
            {

                Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);

                Destroy(other.gameObject);
            }

            if (other.tag == "Boss")
            {

                Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
                //BossHp.Damage(100);
                Debug.Log("HitBoss");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        slowed = 0;
    }
}
