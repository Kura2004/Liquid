using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class AccelBord : MonoBehaviour
{
    [SerializeField] float accel;
    private bool isAccel = false;
    private float accel_time = 0;
    [SerializeField] float end_time = 0;
    private AudioSource se;

    private void Start()
    {
        isAccel = false;
        accel_time = 0;
        se = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isAccel)
        {
            accel_time += Time.deltaTime;

        }

        if (accel_time > end_time)
        {
            isAccel = false;
            accel_time = 0;
            PlayerControlScriptWithRgidBody.player_speed /= accel;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isAccel)
        {
            PlayerControlScriptWithRgidBody.player_speed *= accel;
            isAccel = true;
            Se.Accel();
        }

    }
}
