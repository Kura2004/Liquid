using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class SpringBord : MonoBehaviour
{
    [SerializeField] float accel;
    private bool isSpring;
    private int frame;
    [SerializeField] int end_frame;
    private Rigidbody player;
    private AudioSource se;

    private void Start()
    {
        isSpring = false;
        frame = 0;
        se = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isSpring)
            frame++;

        if (frame == end_frame)
        {
            isSpring = false;
            frame = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isSpring)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
            player.AddForce(transform.TransformDirection(Vector3.up) * accel, ForceMode.Acceleration);
            isSpring = true;
            Se.Accel();
            Debug.Log("Jump");

        }

    }
}