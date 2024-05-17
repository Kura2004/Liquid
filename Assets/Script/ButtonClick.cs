using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] AudioSource click_se;
    public void ClickSE()
    {
        click_se.PlayOneShot(click_se.clip);
    }
}
