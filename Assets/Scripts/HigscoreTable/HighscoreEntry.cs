using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreEntry
{
    public float Score;
    public float Distance;
    public string DataScore;
    public bool newEntry;

    public HighscoreEntry(float score, float distance, string dataScore,bool newEntry)
    {
        Score = score;
        Distance = distance;
        DataScore = dataScore;
        this.newEntry = newEntry;
    }
}
