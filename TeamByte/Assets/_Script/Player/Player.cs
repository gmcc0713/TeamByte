using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image[] heartUI;
    public GameObject gameOverPanel;
    public float f_playerHCount = 3;
    public float f_maxHearts = 3; // 최대 하트 개수
    public float f_currentHearts;
    public bool m_bGuard = false;
    private int i_DelayTime = 3;
    private int i_invincibleTime = 1;
    [SerializeField] GameManager gameManager;
    
    void Start() 
    {
        gameOverPanel.SetActive(false);
        f_currentHearts = f_maxHearts;
        UpdateHeartsUI();
        f_currentHearts = SaveLoadManager.Instance.health;
        UpdateHeartsUI();
    }

    IEnumerator CollideCoroutine()
    {
        m_bGuard = true;
        yield return new WaitForSeconds(i_invincibleTime);
        m_bGuard = false;
    }
    
    void UpdateHeartsUI()
    {
            for (int i = 0; i < heartUI.Length; i++)
            {
                if (i < f_currentHearts)
                {
                    heartUI[i].enabled = true;
                }
                else
                {
                    heartUI[i].enabled = false;
                }
            }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
       if (!m_bGuard &&(collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyObstacle")) )
       {
                Debug.Log("Collide");
                f_currentHearts--;

                if (f_currentHearts <= 0)
                {

                    StartCoroutine(RestartGame());
                    return;
                }
                StartCoroutine(CollideCoroutine());
                UpdateHeartsUI();
       }
     }
    IEnumerator RestartGame() 
    {
        gameManager.isAction = true;
        gameOverPanel.SetActive(true);
        yield return new WaitForSeconds(i_DelayTime);
        Destroy(gameObject);
        SaveLoadManager.Instance.health = 3;
        SceneManager.LoadScene("TitleScene");

    }
}
