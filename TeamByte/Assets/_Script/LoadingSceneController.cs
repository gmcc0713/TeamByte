using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField] Slider loadingBar;
    
    void Start()
    {
        StartCoroutine(LoadingSceneProgress());
    }
    
    public string GetSceneName(Save_Data data)
    {
        switch(data)
        {
            case Save_Data.Tutorial:
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
			case Save_Data.Stage_4_3:
				return "Stage4-3";
            default:
                return "";
		}
    }
    IEnumerator LoadingSceneProgress()
    {
        AsyncOperation op =   SceneManager.LoadSceneAsync(GetSceneName(SaveLoadManager.Instance.GetNextSceneData()));       //�񵿱� ���(���� �ҷ����� ���� �ٸ��۾��� ������)
        op.allowSceneActivation = false;    //���� �񵿱�� �ҷ����϶� ���� �ε��� ������ �ڵ����� �ҷ��� ������ �̵��Ұ��� ����(�ε��ð��� �ʹ� ª������ ���)

        float timer = 0;
        while(!op.isDone)   //bar�� �������� �ϱ����� op�� ������ �ʾ����� ��� ����
        {
            yield return null;
            if (op.progress < 0.9f)     //���� �ε��� 90�� ���� �ε� �ٸ� ä���
            {
                loadingBar.value = op.progress;
            }
            else                        //������ 10�۴� 1�ʵ��� ä��� ���� �ҷ��´�
            {
                timer += Time.unscaledDeltaTime;
                loadingBar.value = Mathf.Lerp(0.9f, 1f, timer);
                if(loadingBar.value >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield return null;
                }
            }

        }
    }
}
