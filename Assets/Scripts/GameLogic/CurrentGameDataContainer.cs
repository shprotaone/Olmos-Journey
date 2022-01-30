using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreContainer", menuName = "Create Score Container", order = 53)]
public class CurrentGameDataContainer : ScriptableObject
{
    [Header("Common Game State")]
    public bool gameIsStarted;
    public bool gameInPaused;
    public bool guideActive;
    public bool showGuideInStart;
    public bool firstGift = false;

    [Header("Current Game Stats")]
    public int coinCollected;
    public bool death;
    public GameObject previousBonus;

    [Header("Progress")]
    public int coin;
    public int buyedToys;
    public int currentCost;
    

}
