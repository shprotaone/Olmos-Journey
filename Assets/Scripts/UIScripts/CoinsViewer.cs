using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text coins;
    [SerializeField] private CommonScoreContainer _container;

    void Start()
    {
        coins.text = _container.coin.ToString(); 
    }
}
