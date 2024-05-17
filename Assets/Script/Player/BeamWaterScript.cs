using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWaterScript : MonoBehaviour
{
    public GameObject explosion;
    private GameObject BeamPoint;
    //[SerializeField] float delete_time;
    //float elapsed_time = 0;

    private void Start()
    {
        BeamPoint = GameObject.FindWithTag("BeamPoint");
    }

    private void Update()
    {
        transform.Rotate(Vector3.back * 10.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //elapsed_time = delete_time;
            //Destroy(other.gameObject);
        }

        if (other.tag == "Boss")
        {
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            BossHp.Damage(100);
            Destroy(gameObject);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //elapsed_time = delete_time;
            Debug.Log("HitBoss");
            BossScript.wave_set();
        }
    }
}
