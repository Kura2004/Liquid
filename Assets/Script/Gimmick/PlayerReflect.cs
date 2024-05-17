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
        }
    }
}
