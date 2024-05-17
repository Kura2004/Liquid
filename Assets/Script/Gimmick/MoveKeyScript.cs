using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveKeyScript : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float trigger_count;
    [SerializeField] GameObject[] key_obj;
    [SerializeField]
    Transform[] key_point;
    MeshRenderer mesh;
    [SerializeField]  Color start;
    [SerializeField] Color end;
    [Range(0f, 1.1f)]
    public float t;
    bool isBreak = false;
    [SerializeField] AudioClip se;
    private void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
        isBreak = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Gas" && !isBreak) 
        {
            t += Time.deltaTime * 0.1f;
            mesh.material.SetColor("_Color", Color.Lerp(start, end, t));
            if (t > 1.0f) 
            {
                for(int i = 0; i < key_obj.Length; i++)
                {
                    GameObject o = Instantiate(key_obj[i], key_point[i].position, Quaternion.identity) as GameObject;
                }

                mesh.material.color = Color.black;
                isBreak = true;
                GetComponent<AudioSource>().PlayOneShot(se);
            }
        }
    }
}
