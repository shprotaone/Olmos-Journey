using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingZone : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionWithSubject>().DecreaseSpeed();
            StartCoroutine(DestroyAction(other));           
            print("StoppingZone");
        }
    }
}


