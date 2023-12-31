using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] Slider loadingBar;

    void Start()
    {
        StartCoroutine(LoadingSceneProgress());
    }

    public string GetSceneName(Save_Data data)
    {
        Debug.Log(data);
        switch (data)
        {
            case Save_Data.Tutorial:
                /*SaveLoadManager.Instance.SetNextScene((int)Save_Data.Stage_1);
                SaveLoadManager.Instance.SetSaveData((int)Save_Data.Stage_1);*/
                SaveLoadManager.Instance.m_bIsFirst = false;
                return "Tutorial";
            case Save_Data.Stage_1:
                return "Stage1";
            case Save_Data.Stage_2:
                return "Stage2";
            case Save_Data.Stage_3:
                return "Stage3";
            case Save_Data.Stage_4_1:
                return "Stage4-1";
            case Save_Data.Stage_4_2:
                return "Stage4-2";
            case Save_Data.Stage_4_1_1:
                return "Stage4-1-1";
            case Save_Data.Stage_4_3:
                return "Stage4-3";
            default:
                return "";
        }
    }
    IEnumerator LoadingSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(GetSceneName(SaveLoadManager.Instance.GetNextSceneData()));       //비동기 방식(씬을 불러오는 도중 다른작업이 가능함)

        op.allowSceneActivation = false;    //씬을 비동기로 불러들일때 씬의 로딩이 끝나면 자동으로 불러온 씬으로 이동할건지 설정(로딩시간이 너무 짧을때를 대비)

        float timer = 0;
        while (!op.isDone)   //bar를 차오르게 하기위해 op가 끝나지 않았을때 계속 실행
        {
            yield return null;
            if (op.progress < 0.9f)     //씬의 로딩이 90퍼 까지 로딩 바를 채운다
            {
                loadingBar.value = op.progress;
            }
            else                        //나머지 10퍼는 1초동안 채운뒤 씬을 불러온다
            {
                timer += Time.unscaledDeltaTime;
                loadingBar.value = Mathf.Lerp(0.9f, 1f, timer);
                if (loadingBar.value >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield return null;
                }
            }

        }
    }
}
