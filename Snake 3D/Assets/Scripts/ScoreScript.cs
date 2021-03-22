using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int score = 0;
    public Text s;
    public void ScoreAdd()
    {
        score++;
        s.text = score.ToString();
    }
}
