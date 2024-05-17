using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit2 : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            PlayerHp.Damage(damage);
        }

        if (other.tag == "Beam")
        {
            Destroy(gameObject);
        }
    }
}
