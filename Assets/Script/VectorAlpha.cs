using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorAlpha : MonoBehaviour
{
    public static Vector3 RandomVector3()
    {
        Vector3 v = Vector3.zero;
        v.x = Random.Range(-1.0f, 1.0f);
        v.y = Random.Range(-1.0f, 1.0f);
        v.z = Random.Range(-1.0f, 1.0f);
        return v;
    }
}
