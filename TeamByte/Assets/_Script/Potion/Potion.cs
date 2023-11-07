using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public GameObject Canvas;
    public Text resultText;
    private int result = 0;
    public Text successText;

    private void Start()
    {
        successText.gameObject.SetActive(false);
    }

    public void Button1OnClick()
    {
        result += 3;
        UpdateResultText();
    }

    public void Button2OnClick()
    {
        result += 5;
        UpdateResultText();
    }

    public void Button3OnClick()
    {
        result += 10;
        UpdateResultText();
    }

    public void Button4OnClick()
    {
        result -= 7;
        UpdateResultText();
    }

    private void UpdateResultText()
    {
        resultText.text = "Result: " + result.ToString();

        if (result == 50)
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
