using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RainScript : MonoBehaviour
{
    [SerializeField] GameObject[] ink;
    [SerializeField] Transform ink_point;
    [SerializeField] float fall_speed;
    [SerializeField] float ink_delete_time;
    Rigidbody rb;
    float time = 0;
    [SerializeField] float create_end_time;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > create_end_time)
            rb.AddForce(Vector3.down * fall_speed, ForceMode.Acceleration);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            GameObject damage_water = Instantiate(ink[(int)Random.Range(0.0f, (float)ink.Length)], ink_point.position,
            Quaternion.identity) as GameObject;
            Destroy(damage_water, ink_delete_time);
            Destroy(gameObject);
        }
    }

    //private void OnBecameInvisible()
    //{
    //    //画面外に行ったら非アクティブにする
    //    gameObject.SetActive(false);
    //}
}
