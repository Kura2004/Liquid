using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;
using Cinemachine;

public class PlayerReflect : MonoBehaviour
{
    Vector3 save_v;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            save_v = PlayerControlScriptWithRgidBody.velocity;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.localPosition -= 3.0f*save_v * Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControlScriptWithRgidBody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            save_v = PlayerControlScriptWithRgidBody.velocity;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.localPosition -= 3.0f * save_v * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerControlScriptWithRgidBody.velocity = Vector3.zero;
        }
    }
}
