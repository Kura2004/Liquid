using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] GameObject[] beam;
    [SerializeField] Transform BeamPoint;
    [SerializeField] GameObject battery;
    [SerializeField] float destroy_time;
    [SerializeField] float shoot_interval;
    float elapsed_time = 0;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        elapsed_time += Time.deltaTime;
        if (elapsed_time > shoot_interval)
        {
            ShootBall1();
            elapsed_time = 0;
        }
    }

    private void ShootBall1()
    {
        GameObject PlayerShoot =
     Instantiate(beam[0], BeamPoint.position,
     Quaternion.identity) as GameObject;

        PlayerShoot.GetComponent<Rigidbody>().AddForce(
            (BeamPoint.position - (battery.transform.position)).normalized * power + GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
        //AddForce(
        //transform.TransformDirection(power * Vector3.Lerp(BeamPoint.position, Player.transform.position, 1.0f).normalized));

        PlayerShoot.transform.rotation = Quaternion.LookRotation(PlayerShoot.transform.position - BeamPoint.transform.position);

        Destroy(PlayerShoot, destroy_time);
        Se.Shoot();
    }
}


