using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toy : MonoBehaviour
{
    private TreeShop _shop;
    private Image _sprite;
    [SerializeField] private bool _isBuyed;

    private void Start()
    {
        CheckColor();      
    }

    public void CallBuy()
    {
        _shop = GetComponentInParent<TreeShop>();
        _shop.OnBuy += Buy;
        _shop._currentToy = this;
    }

    private void Buy(bool completed)
    {
        _isBuyed = completed;
        CheckColor();
        _shop.OnBuy -= Buy;
    }

    private void CheckColor()
    {
        _sprite = GetComponent<Image>();

        if (!_isBuyed)
        {
            _sprite.color = Color.black;
        }
        else
        {
            _sprite.color = Color.white;
        }
    }
}
