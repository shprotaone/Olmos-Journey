using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreeShop : MonoBehaviour
{
    public delegate void Buy(bool complete);
    public event Buy OnBuy;

    [SerializeField] private GameObject _tree;
    [SerializeField] private GameObject _buyWindow;
    [SerializeField] private CommonScoreContainer _scoreContainer;
    [SerializeField] private CoinsViewer _coinsViewer;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button[] _toys;

    [SerializeField] public Toy _currentToy;

    private int _currentCosts;

    void Start()
    {
        _toys = _tree.GetComponentsInChildren<Button>();
        _currentCosts = 200;
    }

    public void BuyWindowActivate()
    {
        _buyWindow.SetActive(true);
        _cost.text = _currentCosts.ToString();
    }

    public void Buying()
    {
        if(OnBuy != null)
        {
            bool completed = CheckCoins();
            OnBuy(completed);                    
        }
    }

    private bool CheckCoins()
    {
        if (_currentCosts > _scoreContainer.coin)
        {
            print("No coins");
            return false;
        }
        else
        {
            print("Purchase");            
            Purchase();
            return true;
        }
    }

    private void Purchase()
    {      
        _scoreContainer.coin -= _currentCosts;
        _currentCosts += _currentCosts;
        _coinsViewer.RefreshText();
        _buyWindow.SetActive(false);
    }
}
