using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum type
{
    left,
    right,
}

public class DoorMove : MonoBehaviour
{
    [SerializeField] private type type;
    public GameObject Player;
    [SerializeField] private GameObject SummonPositionRight;
    [SerializeField] private GameObject SummonPositionLeft;
    bool canPortal;
    private void Start()
    {
        canPortal = true;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Ãæµ¹");
            if(canPortal)
            {
                canPortal = false;
                if (type == type.left)
                {
                    Player.transform.position = SummonPositionRight.transform.position;
                }
                else
                {
                    Player.transform.position = SummonPositionLeft.transform.position;
                }

                StartCoroutine(PortalCoolTime());
            }

        }
    }
    IEnumerator PortalCoolTime()
    {

        yield return new WaitForSeconds(3f);
        canPortal = true;
    }
}
