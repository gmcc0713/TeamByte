using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public void GameStartBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        // 에디터 상에서는 Play 모드를 중지
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 런타임에서는 애플리케이션을 종료합니다.
        Application.Quit();
#endif
    }

    // Start is called before the first frame update
    public void TitleMove()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
