using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PotionFind : MonoBehaviour
{
    public int potionType;
    public int[] potionCount;
    public TextMeshProUGUI[] potionText;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i< potionText.Length;i++)
            potionCount[i] = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // 0 1 2 3 모두 초기화 해야함.
        for(int i =0;i <potionText.Length;i++)
            SetPotionInfo(i);

    }

    public void SetPotionInfo(int num)
    {
        StringBuilder sb = new();
        if(potionCount[num] <= 5)
            sb.AppendLine($"  :  {potionCount[num]}");

        if (potionCount[num] > 5)
            sb.AppendLine($"  :  MAX");

        potionText[num].text = sb.ToString();
    }
}
