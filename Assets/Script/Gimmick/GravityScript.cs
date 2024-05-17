using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    [SerializeField] float power;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerControlScriptWithRgidBody.player_speed *= power;
            PlayerControlScriptWithRgidBody.enabled_jump = false;
            Debug.Log("Gravity");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerControlScriptWithRgidBody.player_speed /= power;
            PlayerControlScriptWithRgidBody.enabled_jump = true;
            Debug.Log("GravityExit");
        }
    }
}
