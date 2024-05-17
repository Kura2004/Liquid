using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamGasScript : MonoBehaviour
{
    public GameObject explosion;
    private GameObject beam_point;
    private void Start()
    {
        beam_point = GameObject.FindWithTag("BeamPoint");
    }
    private void Update()
    {
        transform.position = beam_point.transform.position;
        transform.rotation = beam_point.transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {

            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.tag == "Boss")
        {

            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            //BossHp.Damage(20);
            Debug.Log("HitBoss");
        }
    }
}
