using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private Transform obj;
    [SerializeField] bool reversal = false;

    private void Start()
    {
        player = GameObject.FindWithTag("GameController");
    }
    void Update()
    {
        LookTarget();
    }

    private void LookTarget()
    {
        obj.rotation = Quaternion.LookRotation(player.transform.position - obj.position);
        if (reversal)
        {
            obj.Rotate(0, 180, 0);
        }
    }
}
