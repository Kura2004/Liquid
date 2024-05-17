using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private GameObject player;
    [SerializeField] Rigidbody HomingRigidbody;

    [SerializeField] float Speed; // �Ǐ]���x
    [SerializeField] float MaxForce; // �ő�̗�
    [SerializeField] float Kp; // P���W��
    [SerializeField] float Ki; // I���W��
    [SerializeField] float Kd; // D���W��

    Vector3 SpeedErrInteg;
    Vector3 PresentSpeedErr;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        Vector3 tgtPos = player.transform.position;
        Vector3 diffDir = (tgtPos - transform.position).normalized; // �^�[�Q�b�g�̕���
        Vector3 tgtSpeed = diffDir * Speed;
        Vector3 speedErr = tgtSpeed - HomingRigidbody.velocity;
        SpeedErrInteg += speedErr * dt;
        Vector3 prevSpeedErr = PresentSpeedErr;
        PresentSpeedErr = speedErr;
        Vector3 speedErrDiff = (PresentSpeedErr - prevSpeedErr) / dt;
        Vector3 force = Kp * speedErr + Ki * SpeedErrInteg + Kd * speedErrDiff; // PID����
        float forceMagnitude = force.magnitude;
        if (forceMagnitude > MaxForce)
        {
            force = force / forceMagnitude * MaxForce; // �͂��ő�l�ɂ���
        }

        HomingRigidbody.AddForce(force, ForceMode.Force);
    }
}
