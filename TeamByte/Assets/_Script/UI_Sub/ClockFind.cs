using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ClockFind : MonoBehaviour
{
    public int clockCount;
    public TextMeshProUGUI clockText;
    // Start is called before the first frame update
    void Start()
    {
        clockCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetClockInfo();
    }


    public void SetClockInfo()
    {
        StringBuilder sb = new();
        sb.AppendLine($"  :  {clockCount}");

        if (clockCount > 7)
            sb.AppendLine($"  :  MAX");
        clockText.text = sb.ToString();
    }
}
