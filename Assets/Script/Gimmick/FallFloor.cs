using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] Rigidbody floor;

    private void Update()
    {
        if (floor.velocity.y > 0)
        {
            floor.velocity = Vector3.zero;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            floor.AddForce(transform.TransformDirection(Vector3.down * power));//, ForceMode.Acceleration);
            Debug.Log("Fall");
        }
            
    }

}
