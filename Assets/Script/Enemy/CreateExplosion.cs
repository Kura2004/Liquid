using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosion : MonoBehaviour
{
    public GameObject explosion;
    public Transform point;
    public float acceleration;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Beam" || other.tag == "Boss") 
        {
            createExplosion();
            Destroy(gameObject);
            Debug.Log("Ex");

        }
    }

    void createExplosion()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject shoot = Instantiate(explosion, point.position + VectorAlpha.RandomVector3(),
Quaternion.identity) as GameObject;
            switch (i)
            {
                case 0:
                    shoot.GetComponent<Rigidbody>().AddForce(
    transform.TransformDirection(Vector3.down * acceleration), ForceMode.Acceleration);
                    Destroy(shoot, 3.0f);
                    break;
                case 1:
                    shoot.GetComponent<Rigidbody>().AddForce(
    transform.TransformDirection(Vector3.up * acceleration), ForceMode.Acceleration);
                    Destroy(shoot, 3.0f);
                    break;
                case 2:
                    shoot.GetComponent<Rigidbody>().AddForce(
    transform.TransformDirection(Vector3.left * acceleration), ForceMode.Acceleration);
                    Destroy(shoot, 3.0f);
                    break;
                case 3:
                    shoot.GetComponent<Rigidbody>().AddForce(
transform.TransformDirection(Vector3.right * acceleration), ForceMode.Acceleration);
                    Destroy(shoot, 3.0f);
                    break;
                case 4:
                    shoot.GetComponent<Rigidbody>().AddForce(
transform.TransformDirection(Vector3.forward * acceleration), ForceMode.Acceleration);
                    Destroy(shoot, 3.0f);
                    break;
                case 5:
                    shoot.GetComponent<Rigidbody>().AddForce(
transform.TransformDirection(Vector3.back * acceleration), ForceMode.Acceleration);
                    Destroy(shoot, 3.0f);
                    break;
            }
        }
    }
}
