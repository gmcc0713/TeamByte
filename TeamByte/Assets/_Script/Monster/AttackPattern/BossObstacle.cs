using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum DamagePlaneType
{
    CheckType = 4,
    DamageType = 10,
}
public class BossObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] warnings;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private DamagePlaneType damagePlaneType;
    void Start()
    {
        StartCoroutine(WarningLineSpawn());
    }

    public IEnumerator WarningLineSpawn()
    {
        for (int i = 0; i < 20; i++)
        {
            foreach (var warning in warnings)
            {
                warning.SetActive(true);
                SpriteRenderer waringPatternRenderer = warning.GetComponent<SpriteRenderer>();

                waringPatternRenderer.color = new Color(1, 0, 0, 0.05f * i);
                

            }
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(WaitForDestroy());
        }
        foreach (var warning in warnings)
            warning.SetActive(false);
        foreach (var ob in obstacles)
            ob.SetActive(true);
        yield return null;
    }
    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds((float)damagePlaneType);
        Destroy(this.gameObject);
    }
}
