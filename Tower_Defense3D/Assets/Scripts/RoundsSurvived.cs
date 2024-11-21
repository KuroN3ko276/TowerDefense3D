using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
    public TMP_Text roundsText;
    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);
        roundsText.text = "0";
        while(round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }
}
