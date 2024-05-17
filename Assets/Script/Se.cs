using Saito.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Se : MonoBehaviour
{
    public static void Accel()
    {
        SoundManager.Instance.PlaySe(SoundManager.SeSoundData.SE.Accel);
    }

    public static void Shoot()
    {
        SoundManager.Instance.PlaySe(SoundManager.SeSoundData.SE.Shoot);
    }

    public static void Gate()
    {
        SoundManager.Instance.PlaySe(SoundManager.SeSoundData.SE.Gate);
    }

    public static void Swicth()
    {
        SoundManager.Instance.PlaySe(SoundManager.SeSoundData.SE.Swicth);
    }
}
