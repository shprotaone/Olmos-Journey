using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingZone : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionWithSubject>().IncreaseSpeed();
            StartCoroutine(DestroyAction(other));            
            print("SpeedingZone");
        }
    }
}
