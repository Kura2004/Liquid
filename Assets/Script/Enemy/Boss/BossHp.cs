using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public static float maxHp;
    public static float currentHp;
    [SerializeField] Slider slider;

    private void Start()
    {
        maxHp = 10000;
        currentHp = maxHp;
    }

    private void Update()
    {
        slider.value = (float)currentHp / (float)maxHp;
    }

    public static void Damage(int damage)
    {
        currentHp = currentHp - damage;
        if (currentHp >= maxHp)
            currentHp = maxHp;

        Debug.Log("After currentHp : " + currentHp);

        if (currentHp < -30.0f)
        {
            LoadScenes.LoadGameOver();
        }
    }


}
