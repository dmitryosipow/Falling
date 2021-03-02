using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSO : ScriptableObject
{
    public int points;

    public void Reset()
    {
        points = 0;
    }

    public void SetScore(int score)
    {
        points = score;
    }
}
