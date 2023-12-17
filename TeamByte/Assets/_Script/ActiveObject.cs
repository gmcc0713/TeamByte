using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject obj;
    public GameObject activeObject()
    { return obj; }
}
