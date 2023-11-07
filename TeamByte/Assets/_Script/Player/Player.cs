using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image[] heartUI;
    public float f_playerHCount = 3;
    public float f_maxHearts = 3; // 최대 하트 개수
    private float f_currentHearts;
    public bool m_bGuard = false;

    void Start()
    {
        f_currentHearts = f_maxHearts;
        UpdateHeartsUI();

    }

    IEnumerator CollideCoroutine()
    {
        m_bGuard = true;
        yield return new WaitForSeconds(1f);
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
            if (!m_bGuard &&(collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy")) )
            {
                Debug.Log("Collide");
                f_currentHearts--;

                if (f_currentHearts <= 0)
                {
                    Destroy(gameObject);
                }
                StartCoroutine(CollideCoroutine());
                UpdateHeartsUI();
            }
        }
}
