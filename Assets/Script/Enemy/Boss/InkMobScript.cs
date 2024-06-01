using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkMobScript : MonoBehaviour
{
    [SerializeField] GameObject ink_mob;

    private void Update()
    {
        ink_mob.transform.parent = transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Beam")
            Destroy(ink_mob);
    }
}
