using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreContainer", menuName = "Create Score Container", order = 53)]
public class CommonScoreContainer : ScriptableObject
{
    public int coin;
    public int buyedToys;
    public int currentCost;
    public bool firstOpen;
    public bool paused;
    public bool guideActive;
    public bool showGuideInStart;
}
