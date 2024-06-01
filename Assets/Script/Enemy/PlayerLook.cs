using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private Transform obj;
    [SerializeField] bool reversal = false;
    [SerializeField] bool freeze_x = false;

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

        if (freeze_x)
        {
            Vector3 c = obj.localEulerAngles;
            c.x = 0;
            obj.localEulerAngles = c;
        }
    }
}
