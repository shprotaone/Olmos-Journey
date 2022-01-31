using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionWithSubject>().MagnetActivate();
            StartCoroutine(DestroyAction(other));
        }
    }
}
