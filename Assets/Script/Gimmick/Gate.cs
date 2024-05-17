using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public static int gate_enemy_count = 10;
    public static int gate_switch_count = 0;
    [SerializeField] int max_enemy_point;
    [SerializeField] int max_switch_point;
    [SerializeField] Transform left_gate;
    [SerializeField] Transform right_gate;
    [SerializeField] float open_speed;
    float save;
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        gate_enemy_count = max_enemy_point;
        gate_switch_count = max_switch_point;
        save = left_gate.localPosition.z;
    }

    void open_gate()
    {
        if (left_gate.localPosition.z == save) { Se.Gate(); }
        Vector3 v = new Vector3(0, 0, open_speed);
        left_gate.localPosition -= v * Time.deltaTime;
        right_gate.localPosition += v * Time.deltaTime;
        if (left_gate.localPosition.z < -30) { open = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if (gate_enemy_count + gate_switch_count <= 0 && !open)
        {
            open_gate();
        }
        Debug.Log("" + gate_enemy_count + gate_switch_count);
        gate_enemy_count = Math.Clamp(gate_enemy_count, 0, max_enemy_point);
        gate_switch_count = Math.Clamp(gate_switch_count, 0, max_switch_point);
    }
}
