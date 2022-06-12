using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    public GameObject LevelPanel;
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject FinishPanel;
    public LevelManage levelmanager;
    private void Update()
    {
        if (levelmanager.BirdQueue.Count == 0 && Enemy.EnemyCount > 0)
        {
            //Time.timeScale = 0;
            FinishPanel.SetActive(true);
            FinishPanel.GetComponent<TextMeshPro>().text = "LOSE";
        }
        else if (Enemy.EnemyCount == 0)
        {
            //Time.timeScale = 0;
            FinishPanel.SetActive(true);
            FinishPanel.GetComponent<TextMeshPro>().text = "WIN";

        }
    }

    public void PlayButton()
    {
        StartPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }
    public void BackButton()
    {
        LevelPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void LoadLevel(string sceneName)
    {
        ScreenManager.Instance.LoadScene(sceneName);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);

    }
    public void PlayBackButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
