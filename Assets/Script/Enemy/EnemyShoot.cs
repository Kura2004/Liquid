using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] Transform BulletPoint;
    [SerializeField] float interval = 3.0f;
    [SerializeField] float power = 10f;
    [SerializeField] int bullet_num = 0;
    int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bullet_num; i++)
        {
            InvokeRepeating("SpawnObj", 0.1f, interval);

        }

    }

    // Update is called once per frame
    void SpawnObj()
    {
        GameObject Bullet =
            Instantiate(obj, BulletPoint.position,
            Quaternion.identity) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddForce(
            transform.TransformDirection(Vector3.forward) * power);

        Destroy(Bullet, interval);
    }

    private void OnTriggerEnter(Collider ohter)
    {
        if (ohter.tag == "Beam")
        {
            hp--;
            Debug.Log(hp);
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}
