using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingOn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
            Patrol.homing_on = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Patrol.homing_on = false;
        }
    }
}
