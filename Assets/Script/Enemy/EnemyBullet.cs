using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject explostion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Vector3 position = other.transform.position;
            position.x += 0.5f;
            other.transform.position = position;

            Instantiate(explostion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
