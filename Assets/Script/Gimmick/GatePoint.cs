using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatePoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int enemy_point;
    [SerializeField] int switch_point;
    [SerializeField] bool swicth = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Beam")
        {
            Gate.gate_enemy_count -= enemy_point;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (swicth && collision.gameObject.tag == "Player")
        {
            Se.Swicth();
            //transform.localScale = Vector3.zero + Vector3.down;
            MeshRenderer mesh = this.GetComponent<MeshRenderer>();
            mesh.material.SetColor("_Color", Color.green);
            swicth = false;
            Gate.gate_switch_count -= switch_point;
        }
    }
}
