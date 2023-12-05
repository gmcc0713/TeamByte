using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public GameObject Canvas;
    public Text resultText;
    private int resultValue = 0;
    public Text successText;
    public int redPotionValue = 3;
    public int GreenPotionValue = 7;
    public int BluePotionValue = 13;
    public int YellowPotionValue = 1;

    private void Start()
    {
        successText.gameObject.SetActive(false);
    }

    public void Button1OnClick()
    {
        resultValue += redPotionValue;
        UpdateResultValue();
    }

    public void Button2OnClick()
    {
        resultValue += GreenPotionValue;
        UpdateResultValue();
    }

    public void Button3OnClick()
    {
        resultValue += BluePotionValue;
        UpdateResultValue();
    }

    public void Button4OnClick()
    {
        resultValue -= YellowPotionValue;
        UpdateResultValue();
    }

    private void UpdateResultValue()
    {
        resultText.text = "Result: " + resultValue.ToString();

        if (resultValue == 50)
        {
            successText.gameObject.SetActive(true);
            StartCoroutine(CloseQuiz());
        }
    }
    private IEnumerator CloseQuiz() 
    {
        yield return new WaitForSeconds(3);
        Canvas.SetActive(false);
    }
}
