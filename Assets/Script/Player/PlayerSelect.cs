using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] GameObject[] childObject;
    [SerializeField] Transform save_point;
    [SerializeField] CinemachineVirtualCamera[] player_camera;
    // Start is called before the first frame update
    void Start()
    {
        all_active_false();
        childObject[0].SetActive(true);
        player_camera[0].Priority = 100;
        save_point.position = childObject[0].transform.position;
        save_point.rotation = childObject[0].transform.rotation;
    }

    void all_active_false()
    {
        for(int i = 0; i < childObject.Length; i++)
        {
            childObject[i].SetActive(false);
            player_camera[i].Priority = 1;
        }
    }

    void set_true(int index)
    {
        childObject[index].SetActive(true);
        player_camera[index].Priority = 100;
        childObject[index].transform.position = save_point.position;
        childObject[index].transform.rotation = save_point.rotation;

        Debug.Log("SetPlayer");
    }

    void save_point_move()
    {
        
        for (int i = 0; i < childObject.Length; i++)
        {
            if (childObject[i].activeSelf)
            {
                save_point.position = childObject[i].transform.position;
                save_point.rotation = childObject[i].transform.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            all_active_false();
            set_true(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            all_active_false();
            set_true(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            all_active_false();
            set_true(2);
        }

        save_point_move();
    }
}
