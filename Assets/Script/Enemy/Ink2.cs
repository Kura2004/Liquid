using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSpread : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        Vector3 scale = new Vector3(1, 0, 1) * speed * Time.deltaTime;
        transform.localScale += scale;
    }
}
