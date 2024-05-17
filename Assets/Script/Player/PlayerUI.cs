using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TMP_Text beam_status;

    private void Start()
    {
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //    shoot_status++;

        //switch (shoot_status % 3)
        //{
        //    case 0:
        //        beam_status.text = "Water";
        //        break;
        //    case 1:
        //        beam_status.text = "Ice";
        //        break;
        //    case 2:
        //        beam_status.text = "Gas";
        //        break;

        //}
    }
}
