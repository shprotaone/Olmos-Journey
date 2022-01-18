using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDeathObstacle : Obstacle
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            EffectActivate(other);
            other.GetComponent<HealthSystem>().QuickDeath();      
        }
    }
}
