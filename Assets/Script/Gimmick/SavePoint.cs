using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] Transform player;
    private void Start()
    {
        Debug.Log("" + PlayerPrefs.GetInt("key1"));
        int load = PlayerPrefs.GetInt("key1");
        if (load == 99)
        {
            Invoke("LoadSave", 0.1f);
        }

    }

    private void Update()
    {

    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        PlayerPrefs.SetInt("key1", 0);
    }

    void LoadSave()
    {
        player.position = transform.position;
        PlayerHp.currentHp = PlayerPrefs.GetFloat("player_hp");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("key1", 99);
            PlayerPrefs.SetFloat("player_hp", PlayerHp.currentHp);
        }
    }
}
