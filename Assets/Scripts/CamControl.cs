using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamControl : MonoBehaviour
{
    public CinemachineVirtualCamera BirdCam;
    public CinemachineVirtualCamera LevelCam;

    private void Start()
    {
        StartCoroutine(StartAnim());
    }
    public void SwitchToLevel()
    {
        BirdCam.Priority = 10;
        LevelCam.Priority = 11;
    }
    public void SwitchToBird()
    {
        BirdCam.Priority = 11;
        LevelCam.Priority = 10;
    }
    public void setBirdCam(GameObject player)
    {
        StartCoroutine(camWait(player));
    }
    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(2f);
        BirdCam.Priority = 11;
        LevelCam.Priority = 10;
    }


    IEnumerator camWait(GameObject player)
    {
        yield return new WaitForSeconds(1.5f);
        BirdCam.Follow = player.transform;

    }
}
