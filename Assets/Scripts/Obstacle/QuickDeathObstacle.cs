using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDeathObstacle : Obstacle
{
    [SerializeField] private GameObject _parentObject;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Action(other));
            other.GetComponent<HealthSystem>().QuickDeath();
            StartCoroutine(DestroyParent());
        }
    }

    private IEnumerator DestroyParent()
    {
        Destroy(_parentObject);

        yield return null;
    }
}
