 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlane : MonoBehaviour
{
    [SerializeField] private GameObject[] planes;
    
    void Start()
    {
        StartCoroutine(WarningLineSpawn());
    }

    public IEnumerator WarningLineSpawn()
    {
        planes[0].SetActive(true);
        SpriteRenderer waringPatternRenderer = planes[0].GetComponent<SpriteRenderer>();
        for (int i = 0; i < 20; i++)
        {
           waringPatternRenderer.color = new Color(1, 0, 0, 0.1f * i);
            yield return new WaitForSeconds(0.1f); 
        }
        StartCoroutine(WaitForDestroy());
        planes[0].SetActive(false);
        planes[1].SetActive(true);
        Debug.Log("ÆÄ±«ÁØºñÁß");
    }
    public IEnumerator WaitForDestroy()
    {
        Debug.Log("ÆÄ±«ÁØºñ");
        yield return new WaitForSeconds(10.0f);
        Debug.Log("ÆÄ±«");
        Destroy(this.gameObject);
    }
}
