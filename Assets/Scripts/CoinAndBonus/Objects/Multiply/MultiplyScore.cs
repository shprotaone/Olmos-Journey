using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyScore : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionWithSubject>().MultiplyCoin();
            StartCoroutine(DestroyAction(other));
        }
    }
}
