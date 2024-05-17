using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] public GameObject[] beam;
    [SerializeField] Transform BeamPoint;
    [SerializeField] public Transform Player;
    [SerializeField] float destroy_time;
    [SerializeField] int shoot_interval;
    private int shoot_status;
    private GameObject Gas;

    private void Start()
    {
        shoot_status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shoot_status++;

        }
            

        switch (shoot_status % 3)
        {
            case 0:
                if (Gas != null)
                {
                    Destroy(Gas);
                }

                if (Input.GetMouseButton(0))
                {
                    ShootBall1();
                }
                else
                {
                }
                break;
            case 1:
                if (Input.GetMouseButtonDown(0))
                {
                    ShootBall2();
                }
                break;
            case 2:
                if (Input.GetMouseButtonDown(0))
                {
                    ShootBall3();
                }

                if(Input.GetMouseButtonUp(0))
                {
                    if (Gas != null)
                    {
                        Destroy(Gas);
                    }
                }
                break;

        }
        
            
    }

    private void ShootBall1()
    {
        GameObject PlayerShoot =
            Instantiate(beam[0], Player.position,
            Quaternion.identity) as GameObject;

        PlayerShoot.GetComponent<Rigidbody>().AddForce(
            (BeamPoint.position - (Player.position )).normalized * power + GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
        //AddForce(
        //transform.TransformDirection(power * Vector3.Lerp(BeamPoint.position, Player.transform.position, 1.0f).normalized));

        PlayerShoot.transform.rotation = Quaternion.LookRotation(PlayerShoot.transform.position - BeamPoint.transform.position);

        Destroy(PlayerShoot, destroy_time);
    }

    void ShootBall2()
    {

        GameObject PlayerShoot =
            Instantiate(beam[1], BeamPoint.position,
            Quaternion.identity) as GameObject;

        PlayerShoot.transform.Rotate(0, Player.localEulerAngles.y, 0);

        Destroy(PlayerShoot, destroy_time);
    }

    void ShootBall3()
    {
        Gas =
           Instantiate(beam[2], BeamPoint.position,
           Quaternion.identity) as GameObject;

        Gas.transform.Rotate(0, Player.localEulerAngles.y, 0);
    }
}
