using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] public GameObject[] beam;
    [SerializeField] Transform BeamPoint;
    [SerializeField] public Transform Player;
    [SerializeField] float destroy_time;
    [SerializeField] float shoot_interval;
    float elapsed_time = 0;
    [SerializeField] bool reversal = false;
    private GameObject Gas;

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
            (BeamPoint.position - (Player.position)).normalized * power + GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
        //AddForce(
        //transform.TransformDirection(power * Vector3.Lerp(BeamPoint.position, Player.transform.position, 1.0f).normalized));

        PlayerShoot.transform.rotation = Quaternion.LookRotation(PlayerShoot.transform.position - BeamPoint.transform.position);
        if (reversal)
        {
            PlayerShoot.transform.Rotate(0, 180, 0);
        }

        Destroy(PlayerShoot, destroy_time);
        Se.Shoot();
    }
}


