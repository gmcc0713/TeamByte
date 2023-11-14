using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject DestoryObstacle;
    private void Start()
    {
        Debug.Log(SceneData.stage4Position);
    }
    // Update is called once per frame
    void Update()
    {
       

        if (SceneData.stage4Position == true)
        {
            player.transform.position = this.transform.position;
            Destroy(this);
            Destroy(DestoryObstacle);
        }
       
    }
}
