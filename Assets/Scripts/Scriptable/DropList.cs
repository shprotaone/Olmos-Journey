using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropList", menuName = "Create Drop List", order = 55)]
public class DropList : ScriptableObject
{
    //пустой бонус всегда 0
    public GameObject[] dropPrefabs;

    public GameObject NextPrefab(int index)
    {
        if (index >= dropPrefabs.Length-1) return dropPrefabs[0];        
        else return dropPrefabs[index + 1];
    }
}
