using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public static void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public static void LoadStageSelect ()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public static void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public static void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public static void LoadStageMeme()
    {
        SceneManager.LoadScene("StageMeme");
    }

    public static void LoadBossStage()
    {
        SceneManager.LoadScene("BossStage");
    }

    public static void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
