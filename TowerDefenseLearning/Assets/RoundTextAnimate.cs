using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTextAnimate : MonoBehaviour
{
    public int textIncreaseTime;

    public Text RoundsText;

    public AnimationCurve curve;

    public void OnEnable()
    {
        StartCoroutine(ShowRounds());
    }
    private IEnumerator ShowRounds()
    {
        yield return new WaitForSeconds(0.5f);

        int iRound = PlayerStats.Rounds;
        int loopTimes = textIncreaseTime * 10;
        for (int i = 0; i < loopTimes; i++)
        {
            float ratio = (float)i / loopTimes;
            int Rounds = Mathf.FloorToInt(iRound * curve.Evaluate(ratio) * +0.5f);
            RoundsText.text = Rounds.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
