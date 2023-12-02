using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public TimelineAsset timelineAsset; // 실행할 타임라인을 Inspector에서 할당합니다.
    public PlayableDirector playableDirector;

    public GameObject[] Cameras;


    // stage 2
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TimelineFunction();
        }
    }

    public void TimelineStart()
    {
        TimelineFunction();
    }

    public void TimelineFunction()
    {
        foreach (var camera in Cameras)
        {
            camera.gameObject.SetActive(true);
        }

        Debug.Log("충돌");
        // 타임라인 실행
        playableDirector.playableAsset = timelineAsset;
        playableDirector.Play();

        foreach (var camera in Cameras)
        {
            camera.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }


}
