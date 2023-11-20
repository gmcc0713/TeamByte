using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{
    public TimelineAsset timelineAsset; // ������ Ÿ�Ӷ����� Inspector���� �Ҵ��մϴ�.
    public PlayableDirector playableDirector;

    public GameObject[] Cameras;
    
    // stage 2
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var camera in Cameras)
            {
                camera.gameObject.SetActive(true);
            }

            Debug.Log("�浹");
            // Ÿ�Ӷ��� ����
            PlayTimeline(timelineAsset); ;

            foreach (var camera in Cameras)
            {
                camera.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }

    // Ÿ�Ӷ��� ���� �Լ�
    private void PlayTimeline(TimelineAsset timeline)
    {
        Debug.Log("Ÿ�Ӷ��� �Լ� ����");
        // Ÿ�Ӷ��� ����
        playableDirector.playableAsset = timeline;
        playableDirector.Play();
    }
}
