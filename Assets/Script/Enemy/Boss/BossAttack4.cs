using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack4 : MonoBehaviour
{
    private float time = 0;
    private const float up_end = 2;

    [SerializeField] Rigidbody rb;
    [SerializeField] float up_power;
    [SerializeField] float fall_power;

    private Transform player;

    [SerializeField] GameObject ink;
    [SerializeField] Transform point;
    [SerializeField] GameObject explosion;

    bool start = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            rb.useGravity = false;
            rb.AddForce(transform.TransformDirection(Vector3.up) * up_power, ForceMode.Acceleration);
        }

        if (time > up_end) 
        {
            rb.velocity = Vector3.zero;
        }

        if (time > up_end && time < up_end + 0.3f)
            transform.Translate(VectorAlpha.RandomVector3() * 0.3f);

        if (time > up_end + 0.5f)
            rb.AddForce(transform.TransformDirection(Vector3.forward) * fall_power, ForceMode.Acceleration);

        if (transform.position.y < -1.0f|| transform.position.y > 70.0f)
        {
            transform.position = new Vector3(0, 3, 0);
            time = 0;
            rb.useGravity = true;
            start = true;
            rb.velocity = Vector3.zero;
            GetComponentAll();
        }

        time += Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Floor") && time > 2) 
        {
            GameObject i = Instantiate(explosion, point.position, Quaternion.identity);
            Destroy(i, 3.0f);
            GameObject j = Instantiate(ink, point.position, Quaternion.identity);

            Destroy(j, 3.0f);

            time = 0;
            start = true;
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.localPosition.x, 3, transform.localPosition.z);
            GetComponentAll();
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = transform.TransformDirection(Vector3.back) * 15.0f;
        }
    }

    void GetComponentAll()
    {
        GetComponent<BossScript>().enabled = true;
        GetComponent<Patrol>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<CreateInk>().enabled = true;
        GetComponent<BossAttack4>().enabled = false;
    }
}
