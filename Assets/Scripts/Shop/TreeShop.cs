using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreeShop : MonoBehaviour
{
    [SerializeField] private GameObject _tree;
    [SerializeField] private GameObject _buyWindow;
    [SerializeField] private GameObject _notEnough;
    [SerializeField] private CurrentGameDataContainer _scoreContainer;
    [SerializeField] private CoinsViewer _coinsViewer;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Image[] _toys;

    private ParticleSystem _effect;

    private int _currentCosts;
    private int[] _buyedArray;

    private void Start()
    {
        _toys = _tree.GetComponentsInChildren<Image>();
        FillArray();
        _currentCosts = _scoreContainer.currentCost;
        _effect = GetComponentInChildren<ParticleSystem>();
        RefreshTree(false);
    }

    public void BuyWindowActivate()
    {
        _buyWindow.SetActive(true);
        _cost.text = _currentCosts.ToString();
    }

    public void Buying()
    {
        bool completed = CheckCoins();

        if (completed)
            _scoreContainer.buyedToys++;

        FillArray();
        RefreshTree(true);
    }

    private bool CheckCoins()
    {
        if (_currentCosts > _scoreContainer.coin)
        {
            print("No coins");
            StartCoroutine(EnoughTextActivate());
            return false;
        }
        else
        {
            print("Purchase");
            GetComponent<AudioSource>().Play();
            _effect.Play();
            Purchase();

            return true;
        }
    }

    private void Purchase()
    {      
        _scoreContainer.coin -= _currentCosts;
        _currentCosts += 50;
        _scoreContainer.currentCost = _currentCosts;
        _coinsViewer.RefreshText();
        _buyWindow.SetActive(false);
    }

    private void CheckColor(Image image,int buyed, bool withBuy)
    {
        image = image.GetComponent<Image>();
        var tempColor = image.color;

        if (buyed == 0)
        {
            tempColor.a = 0f;
            image.color = tempColor;
        }
        else
        {
            tempColor.a = 1;  
            image.color = tempColor;
            CatchToyPosition(image);      
        }
    }

    private void FillArray()
    {
        _buyedArray = new int[_toys.Length];

        for (int i = 0; i < _buyedArray.Length; i++)
        {
            if (i <= _scoreContainer.buyedToys)
                _buyedArray[i] = 1;
            else
                _buyedArray[i] = 0;
        }
    }

    private void RefreshTree(bool withBuy)
    {
        for (int i = 0; i < _toys.Length; i++)
        {
            CheckColor(_toys[i], _buyedArray[i],withBuy);
        }
    }

    private IEnumerator EnoughTextActivate()
    {
        _notEnough.SetActive(true);
        yield return new WaitForSeconds(1f);
        _notEnough.SetActive(false);

        yield break;
    }

    private void CatchToyPosition(Image image)
    {
            _effect.transform.position = image.transform.position;
    }
}
