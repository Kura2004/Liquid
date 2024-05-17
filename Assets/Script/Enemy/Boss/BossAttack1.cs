using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack1 : MonoBehaviour
{
    float time = 0;
    [SerializeField] GameObject ink;
    [SerializeField] Transform ink_point;
    private GameObject attack_effect;
    [SerializeField] float end_time;
    bool create = true;

    // Update is called once per frame
    void Update()
    {

        if (create)
        {
            transform.position = Vector3.up * 3.0f;
            attack_effect = Instantiate(ink, ink_point.position,
            Quaternion.identity) as GameObject;
            create = false;
        }

        time += Time.deltaTime;

        if (time > end_time * 0.7 && attack_effect != null)
        {
            attack_effect.transform.localScale -= new Vector3(1, 0, 1);

            if (attack_effect.transform.localScale.x < 0.1f)
                Destroy(attack_effect);


        }

        if (time > end_time)
        {
            time = 0;
            create = true;
            GetComponent<BossAttack1>().enabled = false;
            GetComponent<BossScript>().enabled = true;
            GetComponent<Patrol>().enabled = true;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<CreateInk>().enabled = true;
            Destroy(attack_effect);
        }

    }
}
