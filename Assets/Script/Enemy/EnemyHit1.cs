using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit1 : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHp.Damage(damage);
        }
    }
}
