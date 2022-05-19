using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public float countDownTime = 3f;
    public TextMeshProUGUI countDownText;
    public void OnStartCountDown ()
    {
        countDownText.gameObject.SetActive(true);
        countDownTime = 3f;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart ()
    {
        while (countDownTime > 0)
        {
            GameController.I.PauseGame();

            countDownText.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        if (countDownTime <= 0)
        {
            GameController.I.ResumeGame();
            countDownText.gameObject.SetActive(false);
        }

        
    }
}
