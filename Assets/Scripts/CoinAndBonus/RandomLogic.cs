using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLogic
{
    private int _totalSum;

    public int SumForRandomSystem(int[] variant)
    {
        int currentNumber;

        foreach (var item in variant)
        {
            _totalSum += item;
        }

        currentNumber = Random.Range(0, _totalSum);

        return currentNumber;
    }

    public bool TrueFalseRandomizer(int balanceValue)
    {
        int result = Random.Range(0, 100);

        return result <= balanceValue;
    }


}
