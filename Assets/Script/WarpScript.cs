using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && tag == "StageSelect")
        {
            LoadScenes.LoadStageSelect();
        }

        if (other.tag == "Player" && tag == "Stage1")
        {
            LoadScenes.LoadStage1();
        }

        if (other.tag == "Player" && tag == "Stage2")
        {
            LoadScenes.LoadStage2();
        }

        if (other.tag == "Player" && tag == "StageMeme")
        {
            LoadScenes.LoadStageMeme();
        }

        if (other.tag == "Player" && tag == "BossStage")
        {
            LoadScenes.LoadBossStage();
        }
    }
}
